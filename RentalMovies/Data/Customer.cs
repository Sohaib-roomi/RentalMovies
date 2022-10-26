using RentalMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalMovies.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth:")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool isSubscribed { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Membership Type:")]
        public byte MembershipTypeId { get; set; }
    }
}