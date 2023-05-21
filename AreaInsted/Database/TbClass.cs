using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_CLASS")]
public partial class TbClass
{
    [Key]
    [Column("ID_CLASS")]
    public int IdClass { get; set; }

    [Column("ID_USER")]
    public int IdUser { get; set; }

    [Column("NM_CLASS")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmClass { get; set; } = null!;

    [Column("NM_WEEKDAY")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmWeekday { get; set; } = null!;

    [Column("NM_CLASSROOM")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NmClassroom { get; set; }

    [Column("NR_TOTAL")]
    public int? NrTotal { get; set; }

    [Column("NM_USER")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NmUser { get; set; }

    [Column("DT_TIME")]
    [Precision(0)]
    public TimeSpan DtTime { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("TbClasses")]
    public virtual TbUser IdUserNavigation { get; set; } = null!;

    [InverseProperty("IdClassNavigation")]
    public virtual ICollection<TbUserClass> TbUserClasses { get; set; } = new List<TbUserClass>();
}
