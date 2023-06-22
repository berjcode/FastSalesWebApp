using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;

public interface IAppRepository<T> where T : Entity
{
  
    DbSet<T> Entity { get; set; }
}

