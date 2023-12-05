using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Koszyk")]
public partial class Koszyk
{
    [Key]
    [Column("IDKoszyka")]
    public int Idkoszyka { get; set; }

    [Column("IDKlienta")]
    public int? Idklienta { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    public int? Ilosc { get; set; }

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
    [InverseProperty("Koszyks")]
    public virtual Klienci? IdklientaNavigation { get; set; }

    [ForeignKey("Idkoszyka")]
    [InverseProperty("Koszyk")]
    public virtual Produkty IdkoszykaNavigation { get; set; } = null!;
}
