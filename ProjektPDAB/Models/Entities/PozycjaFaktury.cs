using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("PozycjaFaktury")]
public partial class PozycjaFaktury
{
    [Key]
    [Column("IDPozycjiFaktury")]
    public int IdpozycjiFaktury { get; set; }

    [Column("IDFaktury")]
    public int? Idfaktury { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Cena { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ilosc { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Rabat { get; set; }

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

    [ForeignKey("Idfaktury")]
    [InverseProperty("PozycjaFakturies")]
    public virtual Faktura? IdfakturyNavigation { get; set; }

    [ForeignKey("Idproduktu")]
    [InverseProperty("PozycjaFakturies")]
    public virtual Produkty? IdproduktuNavigation { get; set; }
}
