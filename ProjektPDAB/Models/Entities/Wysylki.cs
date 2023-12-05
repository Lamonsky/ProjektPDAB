using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Wysylki")]
public partial class Wysylki
{
    [Key]
    [Column("IDWysylki")]
    public int Idwysylki { get; set; }

    [Column("IDZamowienia")]
    public int? Idzamowienia { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataWysylki { get; set; }

    [StringLength(50)]
    public string? SposobWysylki { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? KosztWysylki { get; set; }

    [StringLength(50)]
    public string? AdresDostawy { get; set; }

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

    [ForeignKey("Idzamowienia")]
    [InverseProperty("Wysylkis")]
    public virtual Zamowienium? IdzamowieniaNavigation { get; set; }
}
