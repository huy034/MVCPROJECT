using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPROJECT.Models
{
public class Movie
{
    public int Id { get; set;}
    public string? Title { get; set;}
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set;}
    public string? Genre { get; set;}
    public decimal Price { get; set;}
}
}