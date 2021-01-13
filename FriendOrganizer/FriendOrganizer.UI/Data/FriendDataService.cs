using FriendOrganizer.Infrastructure.Repositories;
using FriendOrganizer.Infrastructure.UnitOfWork;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FriendDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Friend> GetByIdAsync(int id)
        {
            return await _unitOfWork.FriendRepository.GetByIdAsync(id);
        }
    }
}
