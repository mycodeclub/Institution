using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Institution.Models
{
    public class InstitutionContext : DbContext
    {
        public InstitutionContext() : base("name=InstitutionDBConnectionString") { }
        public DbSet<Student> Students { get; set; }
    }
}