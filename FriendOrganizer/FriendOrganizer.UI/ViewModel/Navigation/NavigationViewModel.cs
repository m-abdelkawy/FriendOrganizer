using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.ViewModel.Navigation;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendLookupDataService;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        public NavigationViewModel(IFriendLookupDataService friendLookupDataService
            , IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            Friends.SingleOrDefault(f => f.Id == obj.Id).DisplayMember = obj.DisplayMember;
        }

        private NavigationItemViewModel selectedFriend;

        public NavigationItemViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                OnPropertyChanged();
                if (selectedFriend != null)
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(selectedFriend.Id);
            }
        }

        public async Task LoadAsync()
        {
            var lstFriend = await _friendLookupDataService.GetLstFriendLookupAsync();
            Friends.Clear();
            foreach (var friend in lstFriend)
            {
                Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember));
            }
        }
    }
}
