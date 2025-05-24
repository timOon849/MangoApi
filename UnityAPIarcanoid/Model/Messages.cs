using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnityAPIarcanoid.Model
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int SenderId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));

        public User User { get; set; }
    }
}
