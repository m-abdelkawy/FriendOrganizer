using FriendOrganizer.Infrastructure.Repositories;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Friend> FriendRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
