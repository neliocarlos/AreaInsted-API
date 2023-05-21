using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

[Table("TB_ADDRESS")]
public partial class TbAddress
{
    [Key]
    [Column("ID_ADDRESS")]
    public int IdAddress { get; set; }

    [Column("NM_STATE")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmState { get; set; } = null!;

    [Column("NM_CITY")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmCity { get; set; } = null!;

    [Column("NM_STREET")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmStreet { get; set; } = null!;

    [Column("NM_NEIGHBORHOOD")]
    [StringLength(100)]
    [Unicode(false)]
    public string NmNeighborhood { get; set; } = null!;

    [Column("NR_HOUSE_NUMBER")]
    public int NrHouseNumber { get; set; }

    [Column("NM_COMPLEMENT")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NmComplement { get; set; }

    [Column("NR_ZIP_CODE")]
    public int? NrZipCode { get; set; }

    [InverseProperty("IdAddressNavigation")]
    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
