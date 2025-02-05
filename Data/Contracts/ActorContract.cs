using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Contracts
{
    public record CreateActor
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Sex Sex { get; set; }
        public required Country CountryofBirth { get; set; }
    }

    public record UpdateActor
    {
        public required int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Sex? Sex { get; set; }
        public Country? CountryofBirth { get; set; }
    }

    public class ActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public Country CountryofBirth { get; set; }

        public ICollection<GetActorMovieDTO> ActorMovies { get; set; }
    }

    public class GetActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public Country CountryofBirth { get; set; }
    }
}
