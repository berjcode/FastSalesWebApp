using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickSalesApp.Domain.AppEntities;

public sealed class MainRoleAndRoleRelationShip : Entity
{
    public MainRoleAndRoleRelationShip()
    {

    }
    public MainRoleAndRoleRelationShip(string id,string roleId, string mainRoleId) :base(id)
    {
        RoleId= roleId;
        MainRoleId= mainRoleId;

    }
    [ForeignKey("AppRole")]
    public string RoleId { get; set; }
    public AppRole AppRole { get; set; }

    [ForeignKey("MainRole")]
    public string MainRoleId { get; set; }
    public MainRole MainRole { get; set; }

}

