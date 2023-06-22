namespace QuickSalesApp.Domain.Dtos;

public sealed record ProductUnitDto(
    
    decimal Price,
     int UnitId,
     string UnitName,
     bool isVat,
     decimal  Amount,
     decimal Weight
    );
