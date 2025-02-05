using System.Text.Json.Serialization;
using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Entity
{
    public class Actor
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [JsonConverter(typeof(SexConverter))]
        public required Sex Sex { get; set; }
        [JsonConverter(typeof(CountryConverter))]
        public required Country CountryofBirth { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}
