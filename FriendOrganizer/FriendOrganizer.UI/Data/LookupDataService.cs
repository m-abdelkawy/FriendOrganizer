using FriendOrganizer.Infrastructure.UnitOfWork;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LookupDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LookupItem>> GetLstFriendLookupAsync()
        {
            return (await _unitOfWork.FriendRepository.GetAllAsync())
                .Select(e =>
                new LookupItem()
                {
                    Id = e.Id,
                    DisplayMember = e.FirstName + " " + e.LastName
                })
                .ToList();
        }
    }
}
