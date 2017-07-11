using ApiCobro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiCobro.DAL
{
    public class CobrosDb : DbContext
    {
        public CobrosDb(): base("ConStr")
        {

        }
        public DbSet<Cobros> Cobros { get; set; }
    }
}