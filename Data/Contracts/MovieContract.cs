using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Contracts
{
    public record CreateMovie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public float BoxOfficeGross { get; set; }

        public int? DirectorId { get; set; }
    }

    public record UpdateMovie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Rating { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public float? BoxOfficeGross { get; set; }
        public int? DirectorId { get; set; }
    }

    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public float BoxOfficeGross { get; set; }
        public int? DirectorId { get; set; }
        public ICollection<GetMovieActorDTO> ActorMovies { get; set; }
    }

    public class GetMovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }

    public class DirectorMovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public float BoxOfficeGross { get; set; }
    }
}
