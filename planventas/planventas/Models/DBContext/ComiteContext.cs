using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using planventas.Data;

#nullable disable

namespace planventas.Models.DBContext
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

 
        public virtual DbSet<Pos_Tipo_Instalacion> Pos_Tipos_Instalacion { get; set; }
        public virtual DbSet<Pos_Instalacion> Pos_Instalaciones { get; set; }
        public virtual DbSet<Pos_Entrenador> Pos_Entrenadores { get; set; }
        public virtual DbSet<Pos_Servicio> Pos_Servicios { get; set; }
        public virtual DbSet<RmUser> Rm_Usuarios { get; set; }
        public virtual DbSet<TemporalSale> TemporalSales { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<RmUser>().ToTable("Rm_Usuarios");
            modelBuilder.Entity<TemporalSale>().ToTable("Temporal_Sales");

        }



    }
}
