using Microsoft.EntityFrameworkCore;
using SWProvincias_Goyena.Models;

namespace SWProvincias_Goyena.Data
{
    public class DBProvinciasContext : DbContext
    {
        public DBProvinciasContext(DbContextOptions<DBProvinciasContext> options) : base(options) { }

        //Propiedades
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
