using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendDataService _friendDataService;

        private Friend selectedFriend;

        public Friend SelectedFriend
        {
            get { return selectedFriend; }
            private set
            {
                selectedFriend = value;
                OnPropertyChanged();
            }
        }


        public FriendDetailViewModel(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
        }

        public async Task LoadAsync(int id)
        {
            SelectedFriend = await _friendDataService.GetByIdAsync(id);
        }
    }
}
