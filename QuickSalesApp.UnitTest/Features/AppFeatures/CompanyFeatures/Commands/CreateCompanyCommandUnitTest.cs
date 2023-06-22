using Moq;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

	public CreateCompanyCommandUnitTest()
	{
		_companyService = new();
	}

	//[Fact]
	//public async Task CompanyShouldBeNull(CancellationToken cancellationToken)
	//{
	//	Company company = (await _companyService.Object.GetCompanyByName("abdullah",cancellationToken))!;

	//	company.ShouldBeNull();

	//}

	[Fact]
	public async Task CreateCompanyCommandResponseShouldNotBeNull()
	{
		var command = new CreateCompanyCommand(
			Name:"Abdullah",
			Address:"test",
			ServerName:"berjcode",
			DatabaseName:"QuickSalesApp",
            ServerUserId: "",
            ServerPassword: "");
		var handler = new CreateCompanyCommandHandler(_companyService.Object);
		CreateCompanyCommandResponse response = await handler.Handle(command,default);
		response.ShouldNotBeNull();
		response.Message.ShouldNotBeEmpty();
	}

}
