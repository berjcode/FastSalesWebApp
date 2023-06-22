using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.AppEntities.Identity;
using System.Security.Cryptography.X509Certificates;

namespace QuickSalesApp.Domain.Roles;

public sealed class RoleList
{

    public static List<AppRole> GetStaticRoles()
    {
        List<AppRole> appRoles = new List<AppRole>();
        
       
        #region ProductRole
        appRoles.Add(new AppRole(
            title: Product,
            code: ProductCreateCode,
            name: ProductCreateName));

        appRoles.Add(new AppRole(
           title: Product,
           code: ProductUpdateCode,
           name: ProductUpdateName));

        appRoles.Add(new AppRole(
           title: Product,
           code: ProductDeleteCode,
           name: ProductDeleteName));
        appRoles.Add(new AppRole(
           title: Product,
           code: ProductReadCode,
           name: ProductReadName));
        #endregion


        return appRoles;
    }

    public static List<MainRole> GetStaticMainRoles()
    {
        List<MainRole> mainRoles = new List<MainRole>
        {
            new MainRole(
                    Guid.NewGuid().ToString(),"Admin",true),
             new MainRole(
                    Guid.NewGuid().ToString(),"Yönetici",true),
              new MainRole(
                    Guid.NewGuid().ToString(),"Kasiyer",true),
        };
        return mainRoles;

    }
    #region RoleTitleNames
    public static string Product = "Ürünler";
    #endregion

    #region RoleCodeAndNames
    //Create

    public static string ProductCreateCode = "Product.Create";
    public static string ProductCreateName = "Ürün Kayıt";
    //Update

    public static string ProductUpdateCode = "Product.Update";
    public static string ProductUpdateName = "Ürün Güncelleme";
    //Delete  
    public static string ProductDeleteCode = "Product.Delete";
    public static string ProductDeleteName = "Ürün Silme";

    //Get
    public static string ProductReadCode = "Product.Get";
    public static string ProductReadName = "Ürün Okuma";
    #endregion



}

