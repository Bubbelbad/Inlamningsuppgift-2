using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Author (int id, string firstName, string lastName)
    {
        public int Id { get; set; } = id;
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName; 
    }
}
