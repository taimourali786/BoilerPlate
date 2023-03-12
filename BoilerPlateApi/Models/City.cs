using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateApi.Models;

[Table("City")]
public partial class City
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("City")]
    public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();

    [InverseProperty("City")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
