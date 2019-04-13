using SmartCoziness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCoziness.Services
{
    public class TenantsDb
    {
        public static IEnumerable<Tenant> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Tenants.ToList();
            }
        }

        public static Tenant GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Tenants.Find(id);

            }
        }

        public static void Add(Tenant tenant)
        {
            using (var context = new CozySmartContext())
            {
                context.Tenants.Add(tenant);
                context.SaveChanges();
            }
        }

        public static void Update(Tenant tenant)
        {
            using (var context = new CozySmartContext())
            {
                Tenant tenantToUpdate = context.Tenants.Find(tenant.Id);
                tenantToUpdate.FirstName = tenant.FirstName;
                context.SaveChanges();
            }
        }
    }
}