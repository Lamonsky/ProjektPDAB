using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Produkty")]
public partial class Produkty
{
    [Key]
    [Column("IDProduktu")]
    public int Idproduktu { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Cena { get; set; }

    [StringLength(50)]
    public string? OpisProduktu { get; set; }

    [Column("IDKategorii")]
    public int? Idkategorii { get; set; }

    public int? IloscNaStanie { get; set; }

    [StringLength(50)]
    public string? JednostkaMiary { get; set; }

    [StringLength(50)]
    public string? Producent { get; set; }

    [StringLength(50)]
    public string? Uwagi { get; set; }

    [StringLength(50)]
    public string? KtoDodal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyDodal { get; set; }

    [StringLength(50)]
    public string? KtoZmodyfikowal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyZmodyfikowal { get; set; }

    [StringLength(50)]
    public string? KtoUsunal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUsunal { get; set; }

    public bool? CzyAktywny { get; set; }

    [InverseProperty("IdproduktuNavigation")]
    public virtual ICollection<Dostawy> Dostawies { get; set; } = new List<Dostawy>();

    [ForeignKey("Idkategorii")]
    [InverseProperty("Produkties")]
    public virtual Kategorie? IdkategoriiNavigation { get; set; }

    [InverseProperty("IdproduktuNavigation")]
    public virtual ICollection<Naprawy> Naprawies { get; set; } = new List<Naprawy>();

    [InverseProperty("IdproduktuNavigation")]
    public virtual ICollection<PozycjaFaktury> PozycjaFakturies { get; set; } = new List<PozycjaFaktury>();

    [InverseProperty("IdproduktuNavigation")]
    public virtual ICollection<Zamowienium> Zamowienia { get; set; } = new List<Zamowienium>();
}
