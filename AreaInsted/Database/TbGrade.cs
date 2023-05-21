using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_GRADES")]
public partial class TbGrade
{
    [Key]
    [Column("ID_GRADES")]
    public int IdGrades { get; set; }

    [Column("ID_USER_CLASS")]
    public int IdUserClass { get; set; }

    [Column("PROVA1", TypeName = "decimal(18, 0)")]
    public decimal Prova1 { get; set; }

    [Column("PROVA2", TypeName = "decimal(18, 0)")]
    public decimal Prova2 { get; set; }

    [Column("EX_CP1", TypeName = "decimal(18, 0)")]
    public decimal ExCp1 { get; set; }

    [Column("EX_CP2", TypeName = "decimal(18, 0)")]
    public decimal ExCp2 { get; set; }

    [Column("PORTFOLIO", TypeName = "decimal(18, 0)")]
    public decimal Portfolio { get; set; }

    [Column("PROJECT", TypeName = "decimal(18, 0)")]
    public decimal Project { get; set; }

    [Column("EXAM", TypeName = "decimal(18, 0)")]
    public decimal? Exam { get; set; }

    [ForeignKey("IdUserClass")]
    [InverseProperty("TbGrades")]
    public virtual TbUserClass IdUserClassNavigation { get; set; } = null!;
}
