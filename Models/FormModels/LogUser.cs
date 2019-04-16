using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LogUser
    {
       [Display(Name="Email")]
       [Required(ErrorMessage="Email is required.")]
       [EmailAddress]
       public string LoginEmail { get; set; }
       
       [Display(Name="Password")]
       [Required(ErrorMessage="Password is required.")]       
       [DataType(DataType.Password)]
       public string LoginPassword { get; set; }
    }
}