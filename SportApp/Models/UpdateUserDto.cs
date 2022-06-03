﻿namespace SportApp.Models
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public string? PostalCode { get; set; }
    }
}
