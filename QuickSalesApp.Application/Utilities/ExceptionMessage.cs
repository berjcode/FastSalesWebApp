namespace QuickSalesApp.Application.Utilities;

public static class ExceptionMessage
{
    //
    public static string NullDataException { get; set; } = "Herhangi bir veri bulunamadı";
    public static string DeleteNotFoundException { get; set; } = "Silmek İstediğiniz Veri Bulunamadı";
    public static string UpdateNotFoundException { get; set; } = "Güncellemek İstediğiniz Veri Bulunamadı";
    public static string CategoryNotDeleteException { get; set; } = "Silmek İstediğiniz Kategoriye Bağlı Ürünler Olduğu İçin Silinemedi";
    public static string VatTypeNotDeleteException { get; set; } = "Silmek İstediğiniz KDV Türüne Bağlı Ürünler Olduğu İçin Silinemedi";
    public static string ProductTypeNotDeleteException { get; set; } = "Silmek İstediğiniz Stok Türüne Bağlı Ürünler Olduğu İçin Silinemedi";
    public static string UnitNotDeleteException { get; set; } = "Silmek İstediğiniz Birime Bağlı Ürünler Olduğu İçin Silinemedi";
}
