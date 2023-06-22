namespace QuickSalesApp.Domain.Dtos;

public sealed record CustomerDto(
    int Id,
    string Code,
    string Name,
    string CustomerTypeName,
    bool? IsActive
    );
