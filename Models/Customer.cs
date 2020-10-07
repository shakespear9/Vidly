using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{

    
    public class Customer
    {

        //[DataType(DataType)]
        //[Column(TypeName = "Varchar")]
        //[Column("CustomerId", TypeName = "varchar(200)")]
        //[Key]
        public int Id { get; set; }

        // data annotation
        
        [Required(ErrorMessage = "Please enter customer's name.")] // not null
        [StringLength(255)] // data specific length
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}