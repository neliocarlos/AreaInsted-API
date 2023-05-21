using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_USER")]
public partial class TbUser
{
    [Key]
    [Column("ID_USER")]
    public int IdUser { get; set; }

    [Column("ID_ADDRESS")]
    public int IdAddress { get; set; }

    [Column("NM_USER")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmUser { get; set; } = null!;

    [Column("NR_REGISTER")]
    public int NrRegister { get; set; }

    [Column("NR_CPF")]
    public int NrCpf { get; set; }

    [Column("NR_RG")]
    public int? NrRg { get; set; }

    [Column("NM_EXPEDITION")]
    [StringLength(10)]
    [Unicode(false)]
    public string? NmExpedition { get; set; }

    [Column("DT_BIRTHDATE", TypeName = "date")]
    public DateTime DtBirthdate { get; set; }

    [Column("NM_SEX")]
    [StringLength(1)]
    [Unicode(false)]
    public string? NmSex { get; set; }

    [Column("NM_PHONE1")]
    public int NmPhone1 { get; set; }

    [Column("NM_PHONE2")]
    public int? NmPhone2 { get; set; }

    [Column("NM_EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NmEmail { get; set; }

    [Column("NM_PASSWORD")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NmPassword { get; set; }

    [Column("IMG_FILE")]
    public byte[]? ImgFile { get; set; }

    [Column("SN_TEACHER")]
    public bool SnTeacher { get; set; }

    [ForeignKey("IdAddress")]
    [InverseProperty("TbUsers")]
    public virtual TbAddress IdAddressNavigation { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<TbClass> TbClasses { get; set; } = new List<TbClass>();

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<TbUserClass> TbUserClasses { get; set; } = new List<TbUserClass>();
}
