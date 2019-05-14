using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CozySmart.Models
{
    public class CozySmartContext : IdentityDbContext<ApplicationUser>
    {
        public CozySmartContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CozySmartContext Create()
        {
            return new CozySmartContext();
        }

        /// <summary>
        /// Collection managing the bookings of the tenants
        /// </summary>
        public IDbSet<Booking> Bookings { get; set; }
        

        /// <summary>
        /// Collection managing the accommodations
        /// </summary>
        public IDbSet<Accommodation> Accommodations { get; set; }

        /// <summary>
        /// Collection managing the accommodation amenities
        /// </summary>
        public IDbSet<Amenity> Amenities { get; set; }

        /// <summary>
        /// Collection of accommodation types
        /// </summary>
        public IDbSet<Category> Categories { get; set; }

        /// <summary>
        /// Collection of all available locations
        /// </summary>
        public IDbSet<Location> Locations { get; set; }

        /// <summary>
        /// Collection of every availability period of the accommodations
        /// </summary>
        public IDbSet<Availability> Availabilities { get; set; }

        /// <summary>
        /// Collection managing the images of the accommodations
        /// </summary>
        public IDbSet<Image> Images { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Accommodation>()
                        .HasMany<Amenity>(a => a.Amenities)
                        .WithMany(m => m.Accommodations)
                        .Map(ma =>
                        {
                            ma.MapLeftKey("AccommodationId");
                            ma.MapRightKey("AmenityId");
                            ma.ToTable("AccommodationAmenities");
                        });

            
        }

    }
}