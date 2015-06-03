namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnterSpaceMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atrakcija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VrijemeDesavanja = c.DateTime(nullable: false),
                        Dan = c.Int(nullable: false),
                        Ponuda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ponuda", t => t.Ponuda_Id)
                .Index(t => t.Ponuda_Id);
            
            CreateTable(
                "dbo.Izvjestaj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumKreiranja = c.DateTime(nullable: false),
                        Kreator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uposlenik", t => t.Kreator_Id)
                .Index(t => t.Kreator_Id);
            
            CreateTable(
                "dbo.Uposlenik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        Broj_telefona = c.String(),
                        RadnoMjesto = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumPlacanja = c.DateTime(nullable: false),
                        Rezervacija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rezervacija", t => t.Rezervacija_Id)
                .Index(t => t.Rezervacija_Id);
            
            CreateTable(
                "dbo.Rezervacija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumRezervacije = c.DateTime(nullable: false),
                        DatumPolaska = c.DateTime(nullable: false),
                        Klijent_Id = c.Int(),
                        Ponuda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klijent", t => t.Klijent_Id)
                .ForeignKey("dbo.Ponuda", t => t.Ponuda_Id)
                .Index(t => t.Klijent_Id)
                .Index(t => t.Ponuda_Id);
            
            CreateTable(
                "dbo.Klijent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        Broj_telefona = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        DatumRegistracije = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ponuda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Smjestaj = c.String(),
                        TrajanjeDana = c.Int(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kapacitet = c.Int(nullable: false),
                        datumPolaska = c.DateTime(nullable: false),
                        Planeta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planeta", t => t.Planeta_Id)
                .Index(t => t.Planeta_Id);
            
            CreateTable(
                "dbo.Planeta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recenzija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrojcanaOcjena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tekst = c.String(),
                        Ponuda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ponuda", t => t.Ponuda_Id)
                .Index(t => t.Ponuda_Id);
            
            CreateTable(
                "dbo.Menadzer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        UserM = c.String(),
                        PassM = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Narudzbenica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Destinacija = c.String(),
                        BrojPutnika = c.Int(nullable: false),
                        TipOpreme = c.String(),
                        PoslovniSaradnik_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poslovnisaradnik", t => t.PoslovniSaradnik_Id)
                .Index(t => t.PoslovniSaradnik_Id);
            
            CreateTable(
                "dbo.Poslovnisaradnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jib = c.String(),
                        Naziv = c.String(),
                        TipOpreme = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OglasZaPosao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prijavnica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumPrijave = c.DateTime(nullable: false),
                        Kandidat = c.String(),
                        Cv = c.String(),
                        Oglas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OglasZaPosao", t => t.Oglas_Id)
                .Index(t => t.Oglas_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijavnica", "Oglas_Id", "dbo.OglasZaPosao");
            DropForeignKey("dbo.Narudzbenica", "PoslovniSaradnik_Id", "dbo.Poslovnisaradnik");
            DropForeignKey("dbo.Karta", "Rezervacija_Id", "dbo.Rezervacija");
            DropForeignKey("dbo.Rezervacija", "Ponuda_Id", "dbo.Ponuda");
            DropForeignKey("dbo.Recenzija", "Ponuda_Id", "dbo.Ponuda");
            DropForeignKey("dbo.Ponuda", "Planeta_Id", "dbo.Planeta");
            DropForeignKey("dbo.Atrakcija", "Ponuda_Id", "dbo.Ponuda");
            DropForeignKey("dbo.Rezervacija", "Klijent_Id", "dbo.Klijent");
            DropForeignKey("dbo.Izvjestaj", "Kreator_Id", "dbo.Uposlenik");
            DropIndex("dbo.Prijavnica", new[] { "Oglas_Id" });
            DropIndex("dbo.Narudzbenica", new[] { "PoslovniSaradnik_Id" });
            DropIndex("dbo.Recenzija", new[] { "Ponuda_Id" });
            DropIndex("dbo.Ponuda", new[] { "Planeta_Id" });
            DropIndex("dbo.Rezervacija", new[] { "Ponuda_Id" });
            DropIndex("dbo.Rezervacija", new[] { "Klijent_Id" });
            DropIndex("dbo.Karta", new[] { "Rezervacija_Id" });
            DropIndex("dbo.Izvjestaj", new[] { "Kreator_Id" });
            DropIndex("dbo.Atrakcija", new[] { "Ponuda_Id" });
            DropTable("dbo.Prijavnica");
            DropTable("dbo.OglasZaPosao");
            DropTable("dbo.Poslovnisaradnik");
            DropTable("dbo.Narudzbenica");
            DropTable("dbo.Menadzer");
            DropTable("dbo.Recenzija");
            DropTable("dbo.Planeta");
            DropTable("dbo.Ponuda");
            DropTable("dbo.Klijent");
            DropTable("dbo.Rezervacija");
            DropTable("dbo.Karta");
            DropTable("dbo.Uposlenik");
            DropTable("dbo.Izvjestaj");
            DropTable("dbo.Atrakcija");
        }
    }
}
