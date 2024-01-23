using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Dostawcy")]
public partial class Dostawcy
{
    [Key]
    [Column("IDDostawcy")]
    public int Iddostawcy { get; set; }

    [StringLength(50)]
    public string? NazwaDostawcy { get; set; }

    [StringLength(50)]
    public string? NumerTelefonu { get; set; }

    [Column("EMail")]
    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? Miejscowosc { get; set; }

    [StringLength(50)]
    public string? Ulica { get; set; }

    [StringLength(50)]
    public string? NrDomu { get; set; }

    [StringLength(50)]
    public string? NrLokalu { get; set; }

    [StringLength(50)]
    public string? KodPocztowy { get; set; }

    [StringLength(50)]
    public string? Wojewodztwo { get; set; }

    [StringLength(50)]
    public string? Kraj { get; set; }

    [StringLength(50)]
    public string? Uwagi { get; set; }

    [Column("Kto Dodal")]
    [StringLength(50)]
    public string? KtoDodal { get; set; }

    [Column("Kiedy Dodal", TypeName = "datetime")]
    public DateTime? KiedyDodal { get; set; }

    [Column("Kto Zmodyfikowal")]
    [StringLength(50)]
    public string? KtoZmodyfikowal { get; set; }

    [Column("Kiedy Zmodyfikowal", TypeName = "datetime")]
    public DateTime? KiedyZmodyfikowal { get; set; }

    [Column("Kto Usunal")]
    [StringLength(50)]
    public string? KtoUsunal { get; set; }

    [Column("Kiedy Usunal", TypeName = "datetime")]
    public DateTime? KiedyUsunal { get; set; }

    [Column("Czy aktywny")]
    public bool? CzyAktywny { get; set; }

    [InverseProperty("IddostawcyNavigation")]
    public virtual ICollection<Dostawy> Dostawies { get; set; } = new List<Dostawy>();
}
