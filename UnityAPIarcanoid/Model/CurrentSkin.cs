using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnityAPIarcanoid.Model
{
    public class CurrentSkin
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BallSkin")]
        public int BallSkinId { get; set; }
        public BallSkin BallSkin { get; set; }
    }
}
