using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabian.Domain.DTOs
{
    public class CustomerDTO
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
