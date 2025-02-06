namespace MovieDirectorsAPI.Data.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public float BoxOfficeGross { get; set; }

        public int? DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<Cast> Cast{ get; set; } = new List<Cast>();
    }
}
