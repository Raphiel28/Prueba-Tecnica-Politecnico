namespace politecnico
{
    public class Profesores
    {
        public int Id { get; set; }
        public string Name { get; set; } =  string.Empty;
        public bool IsActive { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateInactive   { get; set; }

    }
}
