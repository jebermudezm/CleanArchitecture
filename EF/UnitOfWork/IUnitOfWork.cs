using EF.Repository;
using Entities.Entities;

namespace EF.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Save();

        IRepository<Contact> ContactRepository { get; }

    }
}
