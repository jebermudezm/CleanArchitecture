using EF.Context;
using EF.Repository;
using Entities.Entities;
using System.Diagnostics.CodeAnalysis;

namespace EF.UnitOfWork
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _disposed;
        private IRepository<Contact> _contactRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save() => _context.SaveChanges();

        public IRepository<Contact> ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new Repository<Contact>(_context);

                return _contactRepository;
            }
        }

    }
}
