using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPROJECT.Models
{
public class Employee : public Person
{
    public string? EmployeeId { get; set;}
    public string? FullName { get; set;}
    public int Age { get; set;}
}
}