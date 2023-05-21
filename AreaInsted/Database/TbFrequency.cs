using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_FREQUENCY")]
public partial class TbFrequency
{
    [Key]
    [Column("ID_FREQUENCY")]
    public int IdFrequency { get; set; }

    [Column("ID_USER_CLASS")]
    public int IdUserClass { get; set; }

    [Column("NR_PRESECE")]
    public int NrPresece { get; set; }

    [Column("DT_DATE", TypeName = "date")]
    public DateTime DtDate { get; set; }

    [ForeignKey("IdUserClass")]
    [InverseProperty("TbFrequencies")]
    public virtual TbUserClass IdUserClassNavigation { get; set; } = null!;
}
