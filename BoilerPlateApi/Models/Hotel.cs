using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateApi.Models;

[Table("Hotel")]
public partial class Hotel
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    public double? Rating { get; set; }

    public int CityId { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Hotels")]
    public virtual City City { get; set; } = null!;

    [InverseProperty("Hotel")]
    public virtual ICollection<UserHotelBooking> UserHotelBookings { get; } = new List<UserHotelBooking>();
}
