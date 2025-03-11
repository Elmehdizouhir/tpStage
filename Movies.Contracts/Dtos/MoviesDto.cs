using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Contracts.Dtos;

public record MoviesDto(int Id,string Title, string Description, DateTime CreateDate, string Category);
    