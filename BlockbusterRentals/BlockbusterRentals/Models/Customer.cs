using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterRentals.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter  { get; set; }
        public MembershipType MembershipType { get; set; } // a Navigation property
        public byte MembershipTypeID { get; set; } // a Navigation property, used as the foeign key bc convention
    }
}