using System.Text.Json.Serialization;
using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Entity
{
    public class ActorProfile
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public string Education { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
