using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public Nullable<DateTime> Birthdate { get; set; }
    }
}