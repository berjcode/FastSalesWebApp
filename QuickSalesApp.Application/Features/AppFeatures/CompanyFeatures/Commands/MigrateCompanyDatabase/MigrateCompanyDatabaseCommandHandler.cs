using MediatR;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabaseCommandHandler : ICommandHandler<MigrateCompanyDatabaseCommand, MigrateCompanyDatabaseCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseCommandResponse> Handle(MigrateCompanyDatabaseCommand request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}
