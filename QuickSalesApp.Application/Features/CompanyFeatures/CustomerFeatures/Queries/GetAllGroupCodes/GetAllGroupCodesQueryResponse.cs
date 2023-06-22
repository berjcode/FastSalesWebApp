namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;

public sealed record GetAllGroupCodesQueryResponse(
        List<string> GroupCodes
    );