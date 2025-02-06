using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Contracts
{
    public record CreateCast
    {
        public int ActorId { get; set; }

        public int MovieId { get; set; }
    }

    public record UpdateCast
    {
        public required int Id { get; set; }
        public required int ActorId { get; set; }

        public required int MovieId { get; set; }
    }
    
    public class GetActorMovieDTO
    {
        public int Id { get; set; }
        public GetMovieDTO Movie { get; set; }
    }

    public class GetMovieActorDTO
    {
        public int Id { get; set; }
        public GetActorDTO Actor { get; set; }
    }
}
