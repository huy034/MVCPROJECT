using Microsoft.AspNetCore.Identity;
 
 namespace MVCPROJECT.Models
 {
     public class ApplicationUser : IdentityUser
     {
        [PersonalData]
         public string? FullName { get; set; }
     }
 }