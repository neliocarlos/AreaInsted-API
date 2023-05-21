using AreaInsted.Database;

namespace AreaInsted.Models
{
    public class UserDto
    {
        public int IdUser { get; set; }

        public int IdAdress { get; set; }

        public string NmUser { get; set; } = null!;

        public int NrRegister { get; set; }

        public int NrCpf { get; set; }

        public int? NrRg { get; set; }

        public string? NmExpedition { get; set; }

        public DateTime DtBirthdate { get; set; }

        public string? NmSex { get; set; }

        public int NmPhone1 { get; set; }

        public int? NmPhone2 { get; set; }

        public string? NmEmail { get; set; }

        public string? NmPassword { get; set; }

        public byte[]? ImgFile { get; set; }

        public bool SnTeacher { get; set; }
    }
}
