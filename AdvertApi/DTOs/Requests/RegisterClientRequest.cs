using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApi.DTOs.Requests
{
    
    public class RegisterClientRequest
    {
        [Required]
        public int IdClient { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(12)]
        public string Password { get; set; }

    }
}
