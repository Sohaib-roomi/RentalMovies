﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalMovies.Data
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "Enter Membership")]
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte Discount { get; set; }
    }
}