using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickSalesApp.Domain.AppEntities.Identity;

public sealed class AppUser : IdentityUser<string>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpires { get; set; }
    [Column(TypeName = "varchar(MAX)")]
    public string  UserPhoto { get; set; }


}

