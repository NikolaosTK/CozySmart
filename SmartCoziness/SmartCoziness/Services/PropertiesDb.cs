using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCoziness.Models;

namespace SmartCoziness.Services
{
    /// <summary>
    /// Helper class that is used to manage Properties
    /// </summary>
    public class PropertiesDb
    {
        public static IEnumerable<Property> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Properties.ToList();
            }
        }

        public static Property GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Properties.Find(id);
            }
        }

        public static void Add(Property property)
        {
            using (var context = new CozySmartContext())
            {
                context.Properties.Add(property);
                context.SaveChanges();
            }
        }

        public static void Update(Property property)
        {
            using (var context = new CozySmartContext())
            {
                Property propertyToUpdate = context.Properties.Find(property.Id);
                propertyToUpdate.Title = property.Title;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CozySmartContext())
            {
                Property property = context.Properties.Find(id);
                context.Properties.Remove(property);
                context.SaveChanges();
            }
        }

    }
}