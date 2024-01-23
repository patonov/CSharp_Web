using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppOne.tralala
{
    public class PiratesPlunders
    {
        [ForeignKey(nameof(Pirate))]
        public int PirateId { get; set; }
        public virtual Pirate Pirate { get; set; } = null!;

        [ForeignKey(nameof(Plunder))]
        public int PlunderId { get; set; }
        public Plunder Plunder { get; set; } = null!;
    }
}
