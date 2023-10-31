using System;
using System.ComponentModel.DataAnnotations;

namespace SoheilShop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
