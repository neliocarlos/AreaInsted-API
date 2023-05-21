namespace AreaInsted.Models
{
    public class ClassDto
    {
        public int IdClass { get; set; }

        public int IdUser { get; set; }

        public string NmClass { get; set; } = null!;

        public string NmWeekday { get; set; } = null!;

        public string? NmClassroom { get; set; }

        public int? NrTotal { get; set; }

        public string? Nmuser { get; set; }

        public TimeSpan DtTime { get; set; }
    }
}
