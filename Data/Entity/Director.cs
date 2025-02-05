using MovieDirectorsAPI.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using System.Text.Json.Serialization;
using MovieDirectorsAPI.Converter;

namespace MovieDirectorsAPI.Data.Entity
{
    public class Director
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [JsonConverter(typeof(SexConverter))]
        public required Sex Sex { get; set; }

        [JsonConverter(typeof(CountryConverter))]

        public required Country CountryofBirth { get; set; }
        public required DateOnly DateofBirth { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}