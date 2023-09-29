using System;
using System.Collections.Generic;

namespace Fabian.Infrastructure.Models;

public partial class Customer
{
    public Guid UserId { get; set; }

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

    public string? PasswordSalt { get; set; }
}
