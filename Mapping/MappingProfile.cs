using AutoMapper;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDirector, Director>();
            CreateMap<Director, DirectorDTO>();

            CreateMap<CreateMovie, Movie>();
            CreateMap<UpdateMovie, Movie>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Ignore nulls
            CreateMap<Movie, MovieDTO>();
            CreateMap<Movie, GetMovieDTO>();
            CreateMap<Movie, DirectorMovieDTO>();

            CreateMap<CreateActor, Actor>();
            CreateMap<UpdateActor, Actor>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Ignore nulls
            CreateMap<Actor, ActorDTO>();
            CreateMap<Actor, GetActorDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateCast, Cast>();
            CreateMap<UpdateCast, Cast>();
            CreateMap<Cast, GetActorMovieDTO>();
            CreateMap<Cast, GetMovieActorDTO>();

            CreateMap<CreateActorProfile, ActorProfile>();
            CreateMap<UpdateActorProfile, ActorProfile>();
        }
    }
}
