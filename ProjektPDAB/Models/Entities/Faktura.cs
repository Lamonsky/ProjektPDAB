using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Faktura")]
public partial class Faktura
{
    [Key]
    [Column("IDFaktury")]
    public int Idfaktury { get; set; }

    [StringLength(50)]
    public string? Numer { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DataWystawienia { get; set; }

    [Column("IDKlienta")]
    public int? Idklienta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? TerminPlatnosci { get; set; }

    [Column("IDSposobuPlatnosci")]
    public int? IdsposobuPlatnosci { get; set; }

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
    [InverseProperty("Fakturas")]
    public virtual Klienci? IdklientaNavigation { get; set; }

    [ForeignKey("IdsposobuPlatnosci")]
    [InverseProperty("Fakturas")]
    public virtual SposobPlatnosci? IdsposobuPlatnosciNavigation { get; set; }

    [InverseProperty("IdfakturyNavigation")]
    public virtual ICollection<PozycjaFaktury> PozycjaFakturies { get; set; } = new List<PozycjaFaktury>();
}
