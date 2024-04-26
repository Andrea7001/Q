using Microsoft.EntityFrameworkCore;
using Q.EntidadesNegocio.EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.AccesoADatos.DAL
{
    public class ComunDB : DbContext
    {
        public DbSet<PersonaQ> QB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NFDMETJ\\SQLEXPRESS;Initial Catalog=QDB;Integrated Security=True;Trust Server Certificate=True");
        }



    }
}
