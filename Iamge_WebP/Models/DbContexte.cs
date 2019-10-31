using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Iamge_WebP.Models
{
    public class DbContexte:DbContext
    {
        public DbContexte(DbContextOptions<DbContexte> option):base(option) 
        {
            
        }

        public DbSet<Item> Items { get; set; }
    }
}
