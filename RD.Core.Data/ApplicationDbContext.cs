using Microsoft.EntityFrameworkCore;
using RD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RD.Core.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
