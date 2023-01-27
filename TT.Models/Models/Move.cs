using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Models;

public partial class Move
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("game_id")]
    public int GameId { get; set; }

    [Column("human_move")]
    public byte HumanMove { get; set; }

    [Column("computer_move")]
    public byte ComputerMove { get; set; }

    [Column("execution_date", TypeName = "datetime")]
    public DateTime ExecutionDate { get; set; }

    [Column("winner")]
    public bool? Winner { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("Moves")]
    public virtual Game Game { get; set; } = null!;
}
