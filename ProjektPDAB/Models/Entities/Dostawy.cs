﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektPDAB.Models.Entities;

[Table("Dostawy")]
public partial class Dostawy
{
    [Key]
    [Column("IDDostawy")]
    public int Iddostawy { get; set; }

    [Column("IDDostawcy")]
    public int? Iddostawcy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataDostawy { get; set; }

    [StringLength(50)]
    public string? StatusDostawy { get; set; }

    [Column("IDProduktu")]
    public int? Idproduktu { get; set; }

    public int? Ilosc { get; set; }

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

    [ForeignKey("Iddostawcy")]
    [InverseProperty("Dostawies")]
    public virtual Dostawcy? IddostawcyNavigation { get; set; }

    [ForeignKey("Idproduktu")]
    [InverseProperty("Dostawies")]
    public virtual Produkty? IdproduktuNavigation { get; set; }
}
