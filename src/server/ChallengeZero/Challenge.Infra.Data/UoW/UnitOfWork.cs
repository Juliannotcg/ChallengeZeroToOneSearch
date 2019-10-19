using Challenge.Domain.Interfaces;
using Challenge.Infra.Data.Context;

namespace Challenge.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextEntity _context;

        public UnitOfWork(ContextEntity context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}