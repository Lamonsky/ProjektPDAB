using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

public partial class PozycjeZamowienium
{
    [Key]
    [Column("IDPozycji")]
    public int Idpozycji { get; set; }

    [Column("IDZamowienia")]
    public int? Idzamowienia { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    public int? Ilosc { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? CenaJednostkowa { get; set; }

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

    [ForeignKey("Idpozycji")]
    [InverseProperty("PozycjeZamowienium")]
    public virtual Zamowienium Idpozycji1 { get; set; } = null!;

    [ForeignKey("Idpozycji")]
    [InverseProperty("PozycjeZamowienium")]
    public virtual Produkty IdpozycjiNavigation { get; set; } = null!;
}
