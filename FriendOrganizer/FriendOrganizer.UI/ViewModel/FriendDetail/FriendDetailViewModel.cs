using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendDataService _friendDataService;
        private readonly IEventAggregator _eventAggregator;
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


        public FriendDetailViewModel(IFriendDataService friendDataService, IEventAggregator eventAggregator)
        {
            _friendDataService = friendDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            await _friendDataService.SaveAsync(SelectedFriend);

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = selectedFriend.Id,
                    DisplayMember = $"{selectedFriend.FirstName} {selectedFriend.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            //TODO: Check if friend is valid
            return true;
        }

        private async void OnOpenFriendDetailView(int friend_id)
        {
            await LoadAsync(friend_id);
        }

        public async Task LoadAsync(int id)
        {
            SelectedFriend = await _friendDataService.GetByIdAsync(id);
        }

        public ICommand SaveCommand { get; }
    }
}
