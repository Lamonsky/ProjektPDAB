using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Transakcje")]
public partial class Transakcje
{
    [Key]
    [Column("IDTransakcji")]
    public int Idtransakcji { get; set; }

    [Column("IDKlienta")]
    public int? Idklienta { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataTransakcji { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Kwota { get; set; }

    [Column("IDSposobuPlatnosci")]
    public int? IdsposobuPlatnosci { get; set; }

    [Column("IDZamowienia")]
    public int? Idzamowienia { get; set; }

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
    [InverseProperty("Transakcjes")]
    public virtual Klienci? IdklientaNavigation { get; set; }

    [ForeignKey("IdsposobuPlatnosci")]
    [InverseProperty("Transakcjes")]
    public virtual SposobPlatnosci? IdsposobuPlatnosciNavigation { get; set; }

    [ForeignKey("Idzamowienia")]
    [InverseProperty("Transakcjes")]
    public virtual Zamowienium? IdzamowieniaNavigation { get; set; }
}
