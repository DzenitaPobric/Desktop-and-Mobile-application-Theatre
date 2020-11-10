using AutoMapper;
using ePozoriste.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<Database.Grad, GradInsertRequest>().ReverseMap();

            CreateMap<Database.Zanr, Model.Zanr>();
            CreateMap<Database.Zanr, ZanrInsertRequest>().ReverseMap();

            CreateMap<Database.Predstava, Model.Predstava>();
            CreateMap<Database.Predstava, PredstavaUpsertRequest>().ReverseMap();

            CreateMap<Database.Sponzor, Model.Sponzor>();
            CreateMap<Database.Sponzor, SponzorInsertRequest>().ReverseMap();

            CreateMap<Database.Sala, Model.Sala>();
            CreateMap<Database.Sala, SalaUpsertRequest>().ReverseMap();

            CreateMap<Database.Glumac, Model.Glumac>();
            CreateMap<Database.Glumac, GlumacUpsertRequest>().ReverseMap();

            CreateMap<Database.Uplata, Model.Uplata>();
            CreateMap<Database.Uplata, UplataUpsertRequest>().ReverseMap();

            CreateMap<Database.Sjediste, Model.Sjediste>();
            CreateMap<Database.Sjediste, SjedisteUpsertRequest>().ReverseMap();

            CreateMap<Database.Prikazivanje, Model.Prikazivanje>();
            CreateMap<Database.Prikazivanje, PrikazivanjeUpsertRequest>().ReverseMap();

            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, KorisnikInsertRequest>().ReverseMap();           

            CreateMap<Database.Uloga, Model.Uloga>();

            CreateMap<Database.KorisnikUloga, Model.KorisnikUloga>();

            CreateMap<Database.Kupac, Model.Kupac>();
            CreateMap<Database.Kupac, KupacUpsertRequest>().ReverseMap();

            CreateMap<Database.NagradnaIgra, Model.NagradnaIgra>();
            CreateMap<Database.NagradnaIgra, NagradnaIgraInsertRequest>().ReverseMap();

            CreateMap<Database.Ulaznica, Model.Ulaznica>();
            CreateMap<Database.Ulaznica, UlaznicaUpsertRequest>().ReverseMap();

            CreateMap<Database.Novosti, Model.Novosti>();
            CreateMap<Database.Novosti, NovostiInsertRequest>().ReverseMap();

            CreateMap<Database.Korisnik, Model.KorisnikLogin>();

            CreateMap<Database.Kupac, Model.KorisnikLogin>();

            CreateMap<Database.Rezervacije, Model.Rezervacija>();
            CreateMap<Database.Rezervacije, RezervacijaUpsertRequest>().ReverseMap();

            CreateMap<Database.Komentar, Model.Komentar>();
            CreateMap<Database.Komentar, KomentarUpsertRequest>().ReverseMap();

            CreateMap<Database.Notifikacija, Model.Notifikacija>();
            CreateMap<Database.Notifikacija, NotfikacijaInsertRequest>().ReverseMap();

            CreateMap<Database.PredstavaKupac, Model.PredstavaKupac>();
            CreateMap<Database.PredstavaKupac, PRedstavaKupacInsertRequest>().ReverseMap();

            CreateMap<Database.KupacNagradnaIgra, Model.KupacNagradnaIgra>();
            CreateMap<Database.KupacNagradnaIgra, KupacNagradnaIgraInsertRequest>().ReverseMap();

            CreateMap<Database.GlumacPredstava, Model.GlumacPredstava>();
            CreateMap<Database.GlumacPredstava, GlumacPredstavaInsertRequest>().ReverseMap();

            CreateMap<Database.PredstavaUplata, Model.PredstavaUplata>();
            CreateMap<Database.PredstavaUplata, PredstavaUplataInsertRequest>().ReverseMap();

            CreateMap<Database.Dokument, Model.Dokument>();
            CreateMap<Database.Dokument, DokumentUpsertRequest>().ReverseMap();




            CreateMap<Database.Predstava, Model.Predstava>()
           .ForMember(s => s.NazivZanra, a =>
           a.MapFrom(b => new Database.ePozoristeContext().Zanr.Find(b.ZanrId).Naziv));

            CreateMap<Database.Uplata, Model.Uplata>()
          .ForMember(s => s.sponzor, a =>
          a.MapFrom(b => new Database.ePozoristeContext().Sponzor.Find(b.SponzorId).Naziv));

            CreateMap<Database.Prikazivanje, Model.Prikazivanje>()
          .ForMember(s => s.NazivPredstave, a =>
          a.MapFrom(b => new Database.ePozoristeContext().Predstava.Find(b.PredstavaId).Naziv))
          .ForMember(s => s.NazivSale, a =>
          a.MapFrom(b => new Database.ePozoristeContext().Sala.Find(b.SalaId).Naziv));

            CreateMap<Database.Komentar, Model.Komentar>()
         .ForMember(s => s.NazivPredstave, a =>
         a.MapFrom(b => new Database.ePozoristeContext().Predstava.Find(b.PredstavaId).Naziv))
            .ForMember(s => s.Kupac, a =>
                a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Ime + " " +
                new Database.ePozoristeContext().Kupac.Find(b.KupacId).Prezime));

            CreateMap<Database.Ulaznica, Model.Ulaznica>()
       .ForMember(s => s.prikazivanje, a =>
       a.MapFrom(b => new Database.ePozoristeContext().Prikazivanje.Find(b.PrikazivanjeId).DatumPrikazivanja))
          .ForMember(s => s.kupac, a =>
              a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Ime + " " +
              new Database.ePozoristeContext().Kupac.Find(b.KupacId).Prezime))
           .ForMember(s => s.oznakaSjedista, a =>
              a.MapFrom(b => new Database.ePozoristeContext().Sjediste.Find(b.SjedisteId).Red + " / " +
              new Database.ePozoristeContext().Sjediste.Find(b.SjedisteId).Kolona));


            CreateMap<Database.Rezervacije, Model.Rezervacija>()
           .ForMember(s => s.Kupac, a =>
               a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Ime + " " +
               new Database.ePozoristeContext().Kupac.Find(b.KupacId).Prezime))
            .ForMember(s => s.Prikazivanje, a =>
               a.MapFrom(b => new Database.ePozoristeContext().Prikazivanje.Find(b.PrikazivanjeId).DatumPrikazivanja))
            .ForMember(s => s.MailKupca, a =>
               a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Email))
            .ForMember(s => s.datumPrikazivanja, a =>
               a.MapFrom(b => new Database.ePozoristeContext().Prikazivanje.Find(b.PrikazivanjeId).DatumPrikazivanja));


          



            CreateMap<Database.PredstavaKupac, Model.PredstavaKupac>()
      .ForMember(s => s.NazivPredstave, a =>
      a.MapFrom(b => new Database.ePozoristeContext().Predstava.Find(b.PredstavaId).Naziv))
         .ForMember(s => s.nazivKupca, a =>
             a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Ime + " " +
             new Database.ePozoristeContext().Kupac.Find(b.KupacId).Prezime));

            CreateMap<Database.KupacNagradnaIgra, Model.KupacNagradnaIgra>()
      .ForMember(s => s.nagrada, a =>
      a.MapFrom(b => new Database.ePozoristeContext().NagradnaIgra.Find(b.NagradnaIgraId).Naziv))
         .ForMember(s => s.kupac, a =>
             a.MapFrom(b => new Database.ePozoristeContext().Kupac.Find(b.KupacId).Ime + " " +
             new Database.ePozoristeContext().Kupac.Find(b.KupacId).Prezime));

        }
    }
}
