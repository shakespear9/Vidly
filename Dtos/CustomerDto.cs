using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        // data annotation
        [Required(ErrorMessage = "Please enter customer's name.")] // not null
        [StringLength(255)] // data specific length
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}