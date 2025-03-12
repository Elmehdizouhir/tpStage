using System.ComponentModel.DataAnnotations;

namespace Movies.Domain.Entities
{
    public class Movie
{
    public int Id { get; set; }
    public  string Title { get; set; }  = string.Empty;
    public  string Description { get; set; } = string.Empty;

    public  string Category { get; set; } = string.Empty;
    public DateTime CreateDate { get; set;} 

}
}