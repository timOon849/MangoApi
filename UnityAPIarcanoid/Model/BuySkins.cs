using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnityAPIarcanoid.Model
{
    public class BuySkins
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("BallSkin")]
        public int BallSkinId { get; set; }
        public BallSkin BallSkin { get; set; }
    }
}
