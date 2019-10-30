using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sirket.Models
{
    public class SiparisAPIContext :DbContext
    {
        public SiparisAPIContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Siparis> Sipariss { get; set; }
    }
}
