using Movies.Contracts.Dtos;  // استيراد MoviesDto



namespace Movies.Contracts.Responses;

public record GetMoviesByIdResponse (MoviesDto MoviesDto);