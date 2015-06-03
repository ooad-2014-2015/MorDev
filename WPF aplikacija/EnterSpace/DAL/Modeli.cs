using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace DAL
{
    public class Uposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Broj_telefona { get; set; }
        public string RadnoMjesto { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Rezervacija
    {
        public int Id { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual Ponuda Ponuda { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumPolaska { get; set; }
    }

    public class Recenzija
    {
        public int Id { get; set; }
        public virtual Ponuda Ponuda { get; set; }
        public decimal BrojcanaOcjena { get; set; }
        public string Tekst { get; set; }
    }

    public class Prijavnica
    {
        public int Id { get; set; }
        public virtual OglasZaPosao Oglas { get; set; }
        public DateTime DatumPrijave { get; set; }
        public string Kandidat { get; set; }
        public string Cv { get; set; }
    }

    public class Poslovnisaradnik
    {
        public int Id { get; set; }
        public string Jib { get; set; }
        public string Naziv { get; set; }
        public string TipOpreme { get; set; }
    }

    public class Ponuda
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Planeta Planeta { get; set; }
        public string Opis { get; set; }
        public string Smjestaj { get; set; }
        public int TrajanjeDana { get; set; }
        public decimal Cijena { get; set; }
        public int Kapacitet { get; set; }
        public DateTime datumPolaska { get; set; }
        public ObservableCollection<Atrakcija> Atrakcije { get; set; }
        public ObservableCollection<Recenzija> Recenzije { get; set; }
    }

    public class Planeta
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }

    public class OglasZaPosao
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }

    public class Klijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Broj_telefona { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }


    public class Menadzer
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string UserM { get; set; }
        public string PassM { get; set; }
    }

    public class Karta
    {
        public int Id { get; set; }
        public DateTime DatumPlacanja { get; set; }
        public Rezervacija Rezervacija { get; set; }
    }

    public class Izvjestaj
    {
        public int Id { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Uposlenik Kreator { get; set; }
    }

    public class Atrakcija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public DateTime VrijemeDesavanja { get; set; }
        public int Dan { get; set; }
    }

    public class Narudzbenica
    {
        public int Id{ get; set; }
        public DateTime Datum{ get; set; }
        public string Destinacija{ get; set; }
        public int BrojPutnika{ get; set; }
        public Poslovnisaradnik PoslovniSaradnik{ get; set; }
        public string TipOpreme { get; set; }

    }
}
