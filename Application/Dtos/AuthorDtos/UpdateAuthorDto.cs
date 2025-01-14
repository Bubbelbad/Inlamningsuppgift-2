﻿using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public required Guid AuthorId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} cant be longer than 100 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "Name cant be longer than 100 characters")]
        public required string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }
    }
}
