using MyAspMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAspMvc.DAL
{
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base("DbCon")
        {
        }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
    }
}
