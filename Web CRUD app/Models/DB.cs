using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_CRUD_app.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }
        public DbSet<tblProduct> Products { get; set; }
    }
}