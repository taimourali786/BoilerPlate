using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateApi.Models;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(20)]
    public string? Cnic { get; set; }

    [StringLength(450)]
    public string AspNetId { get; set; } = null!;

    public int? CityId { get; set; }

    [ForeignKey("AspNetId")]
    [InverseProperty("Users")]
    public virtual AspNetUser AspNet { get; set; } = null!;

    [ForeignKey("CityId")]
    [InverseProperty("Users")]
    public virtual City? City { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserHotelBooking> UserHotelBookings { get; } = new List<UserHotelBooking>();
}
