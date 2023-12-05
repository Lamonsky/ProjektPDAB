using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Serwisy")]
public partial class Serwisy
{
    [Key]
    [Column("IDSerwisu")]
    public int Idserwisu { get; set; }

    [StringLength(50)]
    public string? NazwaSerwisu { get; set; }

    [StringLength(50)]
    public string? Kontakt { get; set; }

    [StringLength(50)]
    public string? Adres { get; set; }

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

    [InverseProperty("IdserwisuNavigation")]
    public virtual ICollection<Naprawy> Naprawies { get; set; } = new List<Naprawy>();
}
