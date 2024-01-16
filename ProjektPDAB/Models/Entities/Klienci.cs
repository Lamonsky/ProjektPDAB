using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Klienci")]
public partial class Klienci
{
    [Key]
    [Column("IDKlienta")]
    public int Idklienta { get; set; }

    [StringLength(50)]
    public string? Imie { get; set; }

    [StringLength(50)]
    public string? Nazwisko { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? Telefon { get; set; }

    [Column("IDAdresu")]
    public int? Idadresu { get; set; }

    [Column("NIP_PESEL")]
    [StringLength(50)]
    public string? NipPesel { get; set; }

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

    [InverseProperty("IdklientaNavigation")]
    public virtual ICollection<Faktura> Fakturas { get; set; } = new List<Faktura>();

    [ForeignKey("Idadresu")]
    [InverseProperty("Kliencis")]
    public virtual Adre? IdadresuNavigation { get; set; }

    [InverseProperty("IdklientaNavigation")]
    public virtual ICollection<Transakcje> Transakcjes { get; set; } = new List<Transakcje>();

    [InverseProperty("IdklientaNavigation")]
    public virtual ICollection<Zamowienium> Zamowienia { get; set; } = new List<Zamowienium>();
}
