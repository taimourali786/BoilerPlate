using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateApi.Models;

[Table("UserHotelBooking")]
public partial class UserHotelBooking
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int HotelId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [ForeignKey("HotelId")]
    [InverseProperty("UserHotelBookings")]
    public virtual Hotel Hotel { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserHotelBookings")]
    public virtual User User { get; set; } = null!;
}
