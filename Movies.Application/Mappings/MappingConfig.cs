using System;
using System.Collections.Generic;
using Mapster; 
using Movies.Contracts.Responses;
using Movies.Domain.Entities;
namespace Movies.Application.Mappings
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<List<Movie>, GetMoviesResponse>.NewConfig()
                .Map(dest => dest.moviesDto, src => src);

            TypeAdapterConfig<Movie, GetMoviesByIdResponse>.NewConfig()
                .Map(dest => dest.moviesDto, src => src);
        }
    }
}
