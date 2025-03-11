using System;
using System.Collections.Generic;
using Mapster; 
 

namespace Movies.Application.Mappings
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<List<Movies>, GetMoviesResponse>.NewConfig()
                .Map(dest => dest.MoviesDto, src => src);

            TypeAdapterConfig<Movies, GetMoviesByIdResponse>.NewConfig()
                .Map(dest => dest.MovieDto, src => src);
        }
    }
}
