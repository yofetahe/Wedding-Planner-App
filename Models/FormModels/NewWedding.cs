using System;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class NewWedding
    {
       [Display(Name="Husband Name")]
       [Required(ErrorMessage="Husband name is required.")]
       public string HusbandName { get; set; }
       
       [Display(Name="Wife Name")]
       [Required(ErrorMessage="Wife name is required.")]
       public string WifeName { get; set; }

       [Required(ErrorMessage="Bride and groom picture is required.")]
       [Display(Name="Bride & Groom Picture")]
       public string HusbandWifePicture { get; set; }
       
       [Display(Name="Wedding Date")]
       [Required(ErrorMessage="Wedding date is required.")]
       [DataType(DataType.DateTime)]
       [CustomDate(ErrorMessage="Date must be in the future")]
       public DateTime WeddingDate { get; set; }
       
       [Display(Name="Wedding Address")]
       [Required(ErrorMessage="Address is required.")]
       public string Address { get; set; }
       public int CreatedBy { get; set; }
    }
}