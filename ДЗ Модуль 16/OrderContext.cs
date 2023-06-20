using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ДЗ_Модуль_16
{
    internal class OrderContext : DbContext
    {
        public OrderContext() : base("DBContext") { }

        public DbSet<Order> Orders { get; set; }
    }
}
