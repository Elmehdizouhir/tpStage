using System.ComponentModel.DataAnnotations;

namespace Movies.Domain.Entities
{
    public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }  
    public required string Description { get; set; }
    public required string Category { get; set; }
}
}