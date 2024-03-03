using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public string Updated { get; set; }
        public bool Status { get; set; }
    }
}
