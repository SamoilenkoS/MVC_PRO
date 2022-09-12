using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_DAL.Entities
{
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
