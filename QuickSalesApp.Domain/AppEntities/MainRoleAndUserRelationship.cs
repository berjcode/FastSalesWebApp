using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickSalesApp.Domain.AppEntities;

public sealed class MainRoleAndUserRelationship : Entity
{
    public MainRoleAndUserRelationship()
    {

    }

    public MainRoleAndUserRelationship(string id, string userId, string mainRoleId, string companyId) :base(id)
    {
        UserId= userId;
        MainRoleId = mainRoleId;
        CompanyId= companyId;
    }
    [ForeignKey("AppUser")]
    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
    [ForeignKey("MainRole")]
    public string MainRoleId { get; set; }
    public MainRole MainRole { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company Company { get; set; }
}

