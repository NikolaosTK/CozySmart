using SmartCoziness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCoziness.Services
{
    /// <summary>
    /// Helper class that is used to manage Hosts
    /// </summary>
    public class HostsDb
    {
        public static IEnumerable<Host> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Hosts.ToList();
            }
        }

        public static Host GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Hosts.Find(id);
            }
        }

        public static void Add(Host host)
        {
            using (var context = new CozySmartContext())
            {
                context.Hosts.Add(host);
                context.SaveChanges();
            }
        }

        public static void Update(Host host)
        {
            using (var context = new CozySmartContext())
            {
                Host hostToUpdate = context.Hosts.Find(host.Id);
                hostToUpdate.FirstName = host.FirstName;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CozySmartContext())
            {
                Host host = context.Hosts.Find(id);
                context.Hosts.Remove(host);
                context.SaveChanges();
            }
        }
    }
}