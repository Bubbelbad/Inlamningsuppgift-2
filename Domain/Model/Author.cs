using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Author (string firstName, string lastName)
    {
        public Guid Id { get; set; } = new Guid();
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName; 
    }
}
