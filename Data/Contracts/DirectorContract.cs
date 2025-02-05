using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Data.Contracts
{
    public record CreateDirector
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required Sex Sex { get; set; }
        public required Country CountryofBirth { get; set; }
        public required DateOnly DateofBirth { get; set; }
    }

    public class DirectorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public Country CountryofBirth { get; set; }
        public DateOnly DateofBirth { get; set; }

        public ICollection<DirectorMovieDTO> Movies { get; set; }
    }
}
