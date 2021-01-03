﻿using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel
    {
        public IFriendDataService _friendDataService;
        private Friend _selectedFriend;

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set { _selectedFriend = value; }
        }
            
        public ObservableCollection<Friend> Friends { get; set; }


        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }

        public void Load()
        {
            var lstFriend = _friendDataService.GetAll();
            Friends.Clear();
            foreach (var friend in lstFriend)
            {
                Friends.Add(friend);
            }
        }
        
    }
}
