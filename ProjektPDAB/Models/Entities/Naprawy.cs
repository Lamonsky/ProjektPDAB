using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Naprawy")]
public partial class Naprawy
{
    [Key]
    [Column("IDNaprawy")]
    public int Idnaprawy { get; set; }

    [Column("IDSerwisu")]
    public int? Idserwisu { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    public int? DataNaprawy { get; set; }

    public int? StatusNaprawy { get; set; }

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

    [ForeignKey("Idnaprawy")]
    [InverseProperty("Naprawy")]
    public virtual Produkty IdnaprawyNavigation { get; set; } = null!;

    [ForeignKey("Idserwisu")]
    [InverseProperty("Naprawies")]
    public virtual Serwisy? IdserwisuNavigation { get; set; }
}
