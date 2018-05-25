using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public Nullable<DateTime> Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}