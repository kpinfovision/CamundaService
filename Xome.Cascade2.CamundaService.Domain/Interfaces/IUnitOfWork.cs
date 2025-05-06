using Xome.Cascade2.CamundaService.Domain.Interfaces;

namespace Xome.Cascade2.CamundaService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
      Task<int> SaveChangesAsync();
    }
}
