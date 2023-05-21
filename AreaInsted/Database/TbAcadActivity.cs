using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_ACAD_ACTIVITY")]
public partial class TbAcadActivity
{
    [Key]
    [Column("ID_ACAD_ACTIVITY")]
    public int IdAcadActivity { get; set; }

    [Column("ID_USER_CLASS")]
    public int IdUserClass { get; set; }

    [Column("NM_ACAD_ACTIVITY")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmAcadActivity { get; set; } = null!;

    [Column("DT_DEADLINE", TypeName = "date")]
    public DateTime DtDeadline { get; set; }

    [ForeignKey("IdUserClass")]
    [InverseProperty("TbAcadActivities")]
    public virtual TbUserClass IdUserClassNavigation { get; set; } = null!;
}
