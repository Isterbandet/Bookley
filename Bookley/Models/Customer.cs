﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookley.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]//Data anotations.
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}