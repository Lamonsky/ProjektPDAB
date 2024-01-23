using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjektPDAB.Models.Entities;

namespace ProjektPDAB.Models.Context;

public partial class ProjektEntities : DbContext
{
    public ProjektEntities()
    {
    }

    public ProjektEntities(DbContextOptions<ProjektEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<Dostawcy> Dostawcies { get; set; }

    public virtual DbSet<Dostawy> Dostawies { get; set; }

    public virtual DbSet<Faktura> Fakturas { get; set; }

    public virtual DbSet<Kategorie> Kategories { get; set; }

    public virtual DbSet<Klienci> Kliencis { get; set; }

    public virtual DbSet<Naprawy> Naprawies { get; set; }

    public virtual DbSet<PozycjaFaktury> PozycjaFakturies { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<Produkty> Produkties { get; set; }

    public virtual DbSet<Serwisy> Serwisies { get; set; }

    public virtual DbSet<SposobPlatnosci> SposobPlatnoscis { get; set; }

    public virtual DbSet<Transakcje> Transakcjes { get; set; }

    public virtual DbSet<TypFaktury> TypFakturies { get; set; }

    public virtual DbSet<Zamowienium> Zamowienia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;TrustServerCertificate=True;Integrated Security=True;Database=ProjektPDAB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dostawy>(entity =>
        {
            entity.HasOne(d => d.IddostawcyNavigation).WithMany(p => p.Dostawies).HasConstraintName("FK_Dostawy_Dostawcy");

            entity.HasOne(d => d.IdproduktuNavigation).WithMany(p => p.Dostawies).HasConstraintName("FK_Dostawy_Produkty");
        });

        modelBuilder.Entity<Faktura>(entity =>
        {
            entity.HasOne(d => d.IdklientaNavigation).WithMany(p => p.Fakturas).HasConstraintName("FK_Faktura_Klienci");

            entity.HasOne(d => d.IdsposobuPlatnosciNavigation).WithMany(p => p.Fakturas).HasConstraintName("FK_Faktura_SposobPlatnosci");

            entity.HasOne(d => d.IdtypuFakturyNavigation).WithMany(p => p.Fakturas).HasConstraintName("FK_Faktura_TypFaktury");
        });

        modelBuilder.Entity<Naprawy>(entity =>
        {
            entity.HasOne(d => d.IdproduktuNavigation).WithMany(p => p.Naprawies).HasConstraintName("FK_Naprawy_Produkty");

            entity.HasOne(d => d.IdserwisuNavigation).WithMany(p => p.Naprawies).HasConstraintName("FK_Naprawy_Serwisy");
        });

        modelBuilder.Entity<PozycjaFaktury>(entity =>
        {
            entity.HasOne(d => d.IdfakturyNavigation).WithMany(p => p.PozycjaFakturies).HasConstraintName("FK_PozycjaFaktury_Faktura");

            entity.HasOne(d => d.IdproduktuNavigation).WithMany(p => p.PozycjaFakturies).HasConstraintName("FK_PozycjaFaktury_Produkty");
        });

        modelBuilder.Entity<Produkty>(entity =>
        {
            entity.HasOne(d => d.IdkategoriiNavigation).WithMany(p => p.Produkties).HasConstraintName("FK_Produkty_Kategorie");
        });

        modelBuilder.Entity<Transakcje>(entity =>
        {
            entity.HasOne(d => d.IdklientaNavigation).WithMany(p => p.Transakcjes).HasConstraintName("FK_Transakcje_Klienci");

            entity.HasOne(d => d.IdsposobuPlatnosciNavigation).WithMany(p => p.Transakcjes).HasConstraintName("FK_Transakcje_SposobPlatnosci");

            entity.HasOne(d => d.IdzamowieniaNavigation).WithMany(p => p.Transakcjes).HasConstraintName("FK_Transakcje_Zamowienia");
        });

        modelBuilder.Entity<Zamowienium>(entity =>
        {
            entity.HasOne(d => d.IdklientaNavigation).WithMany(p => p.Zamowienia).HasConstraintName("FK_Zamowienia_Klienci");

            entity.HasOne(d => d.IdproduktuNavigation).WithMany(p => p.Zamowienia).HasConstraintName("FK_Zamowienia_Produkty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
