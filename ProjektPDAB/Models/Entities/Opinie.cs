using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Opinie")]
public partial class Opinie
{
    [Key]
    [Column("IDOpinii")]
    public int Idopinii { get; set; }

    [Column("IDKlienta")]
    public int? Idklienta { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    [StringLength(50)]
    public string? Ocena { get; set; }

    [StringLength(50)]
    public string? Komentarz { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataDodania { get; set; }

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
    [InverseProperty("Opinies")]
    public virtual Klienci? IdklientaNavigation { get; set; }

    [ForeignKey("Idproduktu")]
    [InverseProperty("Opinies")]
    public virtual Produkty? IdproduktuNavigation { get; set; }
}
