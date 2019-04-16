using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User: BaseDataModel
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } = "Normal";
        public List<Wedding> UserWedding { get; set; } = new List<Wedding>();

        public User() { }
        public User(RegUser form)
        {
            FirstName = form.FirstName;
            LastName = form.LastName;
            Email = form.RegEmail;
            Password = form.RegPassword;
        }
    }
}