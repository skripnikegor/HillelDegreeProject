using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DTO.Users
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public int UserProfileId { get; set; }
        public UserProfileDTO UserProfile { get; set; }
    }
}
