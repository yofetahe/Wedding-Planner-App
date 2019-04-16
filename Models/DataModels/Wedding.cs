using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding: BaseDataModel
    {
        [Key]
        public int WeddingId { get; set; }
        public string HusbandName { get; set; }
        public string WifeName { get; set; }
        public string HusbandWifePicture { get; set; }
        public DateTime WeddingDate { get; set; }
        public string Address { get; set; }
        public int CreatedBy { get; set; }
        public List<Guest> Guests { get; set; } = new List<Guest>();

        public Wedding() {}
        public Wedding(NewWedding form)
        {
            HusbandName = form.HusbandName;
            WifeName = form.WifeName;
            WeddingDate = form.WeddingDate;
            HusbandWifePicture = form.HusbandWifePicture;
            Address = form.Address;
            CreatedBy = form.CreatedBy;
        }
    }
}