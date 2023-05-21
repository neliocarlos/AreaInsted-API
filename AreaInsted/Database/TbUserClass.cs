using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_USER_CLASS")]
public partial class TbUserClass
{
    [Key]
    [Column("ID_USER_CLASS")]
    public int IdUserClass { get; set; }

    [Column("ID_USER")]
    public int IdUser { get; set; }

    [Column("ID_CLASS")]
    public int IdClass { get; set; }

    [ForeignKey("IdClass")]
    [InverseProperty("TbUserClasses")]
    public virtual TbClass IdClassNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    [InverseProperty("TbUserClasses")]
    public virtual TbUser IdUserNavigation { get; set; } = null!;

    [InverseProperty("IdUserClassNavigation")]
    public virtual ICollection<TbAcadActivity> TbAcadActivities { get; set; } = new List<TbAcadActivity>();

    [InverseProperty("IdUserClassNavigation")]
    public virtual ICollection<TbFrequency> TbFrequencies { get; set; } = new List<TbFrequency>();

    [InverseProperty("IdUserClassNavigation")]
    public virtual ICollection<TbGrade> TbGrades { get; set; } = new List<TbGrade>();
}
