using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_DAL.Entities
{
    public class Good
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}