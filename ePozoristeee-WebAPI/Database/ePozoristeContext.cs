using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ePozoriste.WebAPI.Database
{
    public partial class ePozoristeContext : DbContext
    {
        public ePozoristeContext()
        {
        }

        public ePozoristeContext(DbContextOptions<ePozoristeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dokument> Dokument { get; set; }
        public virtual DbSet<Glumac> Glumac { get; set; }
        public virtual DbSet<GlumacPredstava> GlumacPredstava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<KupacNagradnaIgra> KupacNagradnaIgra { get; set; }
        public virtual DbSet<NagradnaIgra> NagradnaIgra { get; set; }
        public virtual DbSet<Notifikacija> Notifikacija { get; set; }
        public virtual DbSet<Novosti> Novosti { get; set; }
        public virtual DbSet<Predstava> Predstava { get; set; }
        public virtual DbSet<PredstavaKupac> PredstavaKupac { get; set; }
        public virtual DbSet<PredstavaUplata> PredstavaUplata { get; set; }
        public virtual DbSet<Prikazivanje> Prikazivanje { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Sjediste> Sjediste { get; set; }
        public virtual DbSet<Sponzor> Sponzor { get; set; }
        public virtual DbSet<Ulaznica> Ulaznica { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Uplata> Uplata { get; set; }
        public virtual DbSet<Zanr> Zanr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source =.; initial catalog = 160044_160046; integrated security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.Property(e => e.DokumentId).HasColumnName("DokumentID");

                entity.Property(e => e.FileName).HasMaxLength(40);

                entity.Property(e => e.NazivDokumenta)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Sadrzaj).HasColumnType("image");
            });

            modelBuilder.Entity<Glumac>(entity =>
            {
                entity.Property(e => e.GlumacId).HasColumnName("GlumacID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Slika).HasColumnType("image");
            });

            modelBuilder.Entity<GlumacPredstava>(entity =>
            {
                entity.Property(e => e.GlumacPredstavaId).HasColumnName("GlumacPredstavaID");

                entity.Property(e => e.GlumacId).HasColumnName("GlumacID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Glumac)
                    .WithMany(p => p.GlumacPredstava)
                    .HasForeignKey(d => d.GlumacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GlumacPre__Gluma__49C3F6B7");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.GlumacPredstava)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GlumacPre__Preds__48CFD27E");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv).HasMaxLength(30);
            });

            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.Sadrzaj)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VrijemeKreiranja).HasColumnType("datetime");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Komentar)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Komentar__KupacI__693CA210");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Komentar)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Komentar__Predst__6A30C649");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<KorisnikUloga>(entity =>
            {
                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Koris__656C112C");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Uloga__66603565");
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.BrojTelefona).HasMaxLength(20);

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<KupacNagradnaIgra>(entity =>
            {
                entity.Property(e => e.KupacNagradnaIgraId).HasColumnName("KupacNagradnaIgraID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.NagradnaIgraId).HasColumnName("NagradnaIgraID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.KupacNagradnaIgra)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KupacNagr__Kupac__73BA3083");

                entity.HasOne(d => d.NagradnaIgra)
                    .WithMany(p => p.KupacNagradnaIgra)
                    .HasForeignKey(d => d.NagradnaIgraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KupacNagr__Nagra__72C60C4A");
            });

            modelBuilder.Entity<NagradnaIgra>(entity =>
            {
                entity.Property(e => e.NagradnaIgraId).HasColumnName("NagradnaIgraID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Kraj).HasColumnType("datetime");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).IsRequired();

                entity.Property(e => e.Pocetak).HasColumnType("datetime");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.NagradnaIgra)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NagradnaI__Koris__6FE99F9F");
            });

            modelBuilder.Entity<Notifikacija>(entity =>
            {
                entity.Property(e => e.NotifikacijaId).HasColumnName("NotifikacijaID");

                entity.Property(e => e.DatumSlanja).HasColumnType("datetime");

                entity.Property(e => e.NovostiId).HasColumnName("NovostiID");

                entity.HasOne(d => d.Novosti)
                    .WithMany(p => p.Notifikacija)
                    .HasForeignKey(d => d.NovostiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notifikac__Novos__02084FDA");
            });

            modelBuilder.Entity<Novosti>(entity =>
            {
                entity.Property(e => e.NovostiId).HasColumnName("NovostiID");

                entity.Property(e => e.DatumVrijemeObjave).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Slika).HasColumnType("image");

                entity.Property(e => e.Tekst).IsRequired();

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Novosti)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Novosti__Korisni__7F2BE32F");
            });

            modelBuilder.Entity<Predstava>(entity =>
            {
                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Opis).HasMaxLength(200);

                entity.Property(e => e.Reziser)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Predstava)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predstava__ZanrI__403A8C7D");
            });

            modelBuilder.Entity<PredstavaKupac>(entity =>
            {
                entity.Property(e => e.PredstavaKupacId).HasColumnName("PredstavaKupacID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.PredstavaKupac)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predstava__Kupac__5BE2A6F2");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.PredstavaKupac)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predstava__Preds__5AEE82B9");
            });

            modelBuilder.Entity<PredstavaUplata>(entity =>
            {
                entity.Property(e => e.PredstavaUplataId).HasColumnName("PredstavaUplataID");

                entity.Property(e => e.DatumUplate).HasColumnType("datetime");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.UplataId).HasColumnName("UplataID");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.PredstavaUplata)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predstava__Preds__571DF1D5");

                entity.HasOne(d => d.Uplata)
                    .WithMany(p => p.PredstavaUplata)
                    .HasForeignKey(d => d.UplataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predstava__Uplat__5812160E");
            });

            modelBuilder.Entity<Prikazivanje>(entity =>
            {
                entity.Property(e => e.PrikazivanjeId).HasColumnName("PrikazivanjeID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DatumPrikazivanja).HasColumnType("datetime");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Prikazivanje)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prikazivanje_PredstavaID");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Prikazivanje)
                    .HasForeignKey(d => d.SalaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prikazivanje_SalaID");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId);

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.DatumRezervacije).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PrikazivanjeId).HasColumnName("PrikazivanjeID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Kupac__4E88ABD4");

                entity.HasOne(d => d.Prikazivanje)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.PrikazivanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Prika__4F7CD00D");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.Property(e => e.Naziv).HasMaxLength(15);
            });

            modelBuilder.Entity<Sjediste>(entity =>
            {
                entity.Property(e => e.SjedisteId).HasColumnName("SjedisteID");

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.SalaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sjediste__SalaID__3B75D760");
            });

            modelBuilder.Entity<Sponzor>(entity =>
            {
                entity.Property(e => e.SponzorId).HasColumnName("SponzorID");

                entity.Property(e => e.BrojTelefona)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ulaznica>(entity =>
            {
                entity.Property(e => e.UlaznicaId).HasColumnName("UlaznicaID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PrikazivanjeId).HasColumnName("PrikazivanjeID");

                entity.Property(e => e.Qrkod)
                    .IsRequired()
                    .HasColumnName("QRKod")
                    .HasColumnType("image");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.SjedisteId).HasColumnName("SjedisteID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Ulaznica)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznica__KupacI__787EE5A0");

                entity.HasOne(d => d.Prikazivanje)
                    .WithMany(p => p.Ulaznica)
                    .HasForeignKey(d => d.PrikazivanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznica__Prikaz__76969D2E");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Ulaznica)
                    .HasForeignKey(d => d.RezervacijaId)
                    .HasConstraintName("FK__Ulaznica__Rezerv__797309D9");

                entity.HasOne(d => d.Sjediste)
                    .WithMany(p => p.Ulaznica)
                    .HasForeignKey(d => d.SjedisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznica__Sjedis__778AC167");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.Property(e => e.UplataId).HasColumnName("UplataID");

                entity.Property(e => e.DatumUplate).HasColumnType("datetime");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SponzorId).HasColumnName("SponzorID");

                entity.Property(e => e.Svrha).HasMaxLength(200);

                entity.HasOne(d => d.Sponzor)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.SponzorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uplata__SponzorI__5441852A");
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
