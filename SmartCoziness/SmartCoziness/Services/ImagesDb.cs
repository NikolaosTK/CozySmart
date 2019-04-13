using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCoziness.Models;
namespace SmartCoziness.Services
{
    public class ImagesDb
    {
        public static IEnumerable<Image> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Images.ToList();
            }
        }

        public static Image GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Images.Find(id);
            }
        }

        public static void Add(Image image)
        {
            using (var context = new CozySmartContext())
            {
                context.Images.Add(image);
                context.SaveChanges();
            }
        }

        public static void Update(Image image)
        {
            using (var context = new CozySmartContext())
            {
                Image imageToUpdate = context.Images.Find(image.Id);
                imageToUpdate.ImageUrl = image.ImageUrl;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CozySmartContext())
            {
                Image image = context.Images.Find(id);
                context.Images.Remove(image);
                context.SaveChanges();
            }
        }
    }
}