using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Models;

public partial class Game
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    
    public string Name { get; set; } = null!;

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("gamer_name")]
    [StringLength(50)]
    
    public string? GamerName { get; set; }

    [Column("human_wins")]
    public int? HumanWins { get; set; }

    [Column("computer_wins")]
    public int? ComputerWins { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<Move> Moves { get; } = new List<Move>();
}
