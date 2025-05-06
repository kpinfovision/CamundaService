using Xome.Cascade2.CamundaService.Domain.Interfaces;
using Xome.Cascade2.CamundaService.Infrastructure.Data;

namespace Xome.Cascade2.CamundaService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(
            AppDbContext context
           
            )
        {
            _context = context;           
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
