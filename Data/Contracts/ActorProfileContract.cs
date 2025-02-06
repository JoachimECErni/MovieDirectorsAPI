using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Contracts
{
    public record CreateActorProfile
    {
        public int ActorId { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public string Education { get; set; }
    }

    public record UpdateActorProfile
    {
        public required int Id { get; set; }
        public required int ActorId { get; set; }
        public string? Biography { get; set; }
        public string? Nationality { get; set; }
        public string? Education { get; set; }
    }

    public class ActorProfileDTO
    {
        public int Id { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public string Education { get; set; }
    }
}
