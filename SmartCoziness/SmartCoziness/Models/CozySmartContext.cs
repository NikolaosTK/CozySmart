using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SmartCoziness.Models
{
    public class CozySmartContext : DbContext
    {
        const string connectionString = @"Data Source=DESKTOP-2REICNV\SQLEXPRESS01;Initial Catalog=CozySmart;Integrated Security=True";

        public CozySmartContext() : base(connectionString) { }

        /// <summary>
        /// Collection managing the hosts
        /// </summary>
        public DbSet<Host> Hosts { get; set; }

        /// <summary>
        /// Collection managing the tenants
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Collection managing the accommodations
        /// </summary>
        public DbSet<Accommodation> Accommodations { get; set; }

        /// <summary>
        /// Collection managing the bookings of the tenants/accommodations
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Collection managing the images of the accommodations
        /// </summary>
        public DbSet<Image> Images { get; set; }

    }
}