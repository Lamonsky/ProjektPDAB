using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("TypFaktury")]
public partial class TypFaktury
{
    [Key]
    [Column("IDTypuFaktury")]
    public int IdtypuFaktury { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [Column("StawkaVAT")]
    public int? StawkaVat { get; set; }

    [StringLength(50)]
    public string? Skrot { get; set; }

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

    [InverseProperty("IdtypuFakturyNavigation")]
    public virtual ICollection<Faktura> Fakturas { get; set; } = new List<Faktura>();
}
