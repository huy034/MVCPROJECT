using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCPROJECT.Models.Entities
{
    [Table("Person")]
public class Person
{
    [Key]
    public string? PersonId { get; set;}
    public string? FullName { get; set;}
    public string? Address { get; set;}
}
}