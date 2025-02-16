using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPROJECT.Models
{
public class Person
{
    public string? PersonId { get; set;}
    public string? FullName { get; set;}
    public string? Address { get; set;}
}
}