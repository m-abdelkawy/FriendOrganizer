using FriendOrganizer.DataAcess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.Infrastructure.Repositories
{
    //public interface IFriendRepository : IRepository<Friend>
    //{

    //}
    public class FriendRepository : GenericRepository<Friend>/*, IFriendRepository*/
    {
        public FriendRepository(FriendOrganizerDbContext ctx) : base(ctx) { }
    }
}
