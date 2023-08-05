using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIDemo2.Models.Entity.InputAccount
{
    public class InputAccount
    {
        [Key]
        [Column("ID")]
        [StringLength(50)]
        [Unicode(false)]
        public string Id { get; set; } = null!;

        [Column("LoginID")]
        [StringLength(50)]
        public string? LoginId { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }
    }
}
