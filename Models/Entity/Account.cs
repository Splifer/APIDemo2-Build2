using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIDemo2.Models.Entity;

[Table("Account")]
public partial class Account
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
