using FriendOrganizer.DataAcess;
using FriendOrganizer.Infrastructure.Repositories;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected FriendOrganizerDbContext _ctx;
        public UnitOfWork(FriendOrganizerDbContext ctx)
        {
            _ctx = ctx;
        }

        private IRepository<Friend> friendRepository;

        public IRepository<Friend> FriendRepository
        {
            get 
            { // lazy initialization
                if (friendRepository == null)
                    friendRepository = new FriendRepository(_ctx);
                return friendRepository;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
