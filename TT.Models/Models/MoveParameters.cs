using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TT.Models.Models
{
    public class MoveParameters
    {
        [Range(1, 3, ErrorMessage = "Enter a value between 1 and 3")]
        public byte Move { get; set; }
    }
}
