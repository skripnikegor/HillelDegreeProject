using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Models
{
    internal class UserProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        private PasswordPropertyTextAttribute Password { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
    }
}
