using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ClientCRUD.Models
{
    [Owned]
    public class Address
    {
        public string ZipCode { get; set; } = string.Empty;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }

    }
}