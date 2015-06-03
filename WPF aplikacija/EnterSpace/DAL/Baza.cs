using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Baza : DbContext
    {
        public Baza()
            : base("EnterSpaceDB2")
        {
        }
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Prijavnica> Prijavnice { get; set; }
        public DbSet<Poslovnisaradnik> Poslovnisaradnici { get; set; }
        public DbSet<Ponuda> Ponude { get; set; }
        public DbSet<Planeta> Planete { get; set; }
        public DbSet<OglasZaPosao> OglasiZaPosao { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Menadzer> Menadzeri { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Izvjestaj> Izvjestaji { get; set; }
        public DbSet<Atrakcija> Atrakcije { get; set; }
        public DbSet<Narudzbenica> Narudzbenice { get; set; }

        //za onemogucavanje automatskog dodavanja mnozine
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}