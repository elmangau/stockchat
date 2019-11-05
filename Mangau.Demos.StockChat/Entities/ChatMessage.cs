using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangau.Demos.StockChat.Entities
{
    [Table("scchatmessage")]
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long PostedById { get; set; }

        public User PostedBy { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        [MaxLength(100000)]
        public string Message{ get; set; }
    }
}
