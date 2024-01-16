using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Pracownicy")]
public partial class Pracownicy
{
    [Key]
    public int Idpracownika { get; set; }

    [StringLength(50)]
    public string? Imie { get; set; }

    [StringLength(50)]
    public string? Nazwisko { get; set; }

    [StringLength(50)]
    public string? Stanowisko { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataZatrudnienia { get; set; }

    [Column("IDAdresu")]
    public int? Idadresu { get; set; }

    [StringLength(50)]
    public string? Telefon { get; set; }

    [Column("EMail")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Pensja { get; set; }

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

    [ForeignKey("Idadresu")]
    [InverseProperty("Pracownicies")]
    public virtual Adre? IdadresuNavigation { get; set; }
}
