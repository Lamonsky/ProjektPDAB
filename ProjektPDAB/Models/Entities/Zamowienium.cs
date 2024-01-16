using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

public partial class Zamowienium
{
    [Key]
    [Column("IDZamowienia")]
    public int Idzamowienia { get; set; }

    [Column("IDKlienta")]
    public int? Idklienta { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataZamowienia { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    public int? Ilosc { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

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

    [ForeignKey("Idklienta")]
    [InverseProperty("Zamowienia")]
    public virtual Klienci? IdklientaNavigation { get; set; }

    [ForeignKey("Idproduktu")]
    [InverseProperty("Zamowienia")]
    public virtual Produkty? IdproduktuNavigation { get; set; }
}
