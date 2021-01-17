using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel.Navigation
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private int id;
        private string displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            this.Id = id;
            this.DisplayMember = displayMember;
        }

        public string DisplayMember
        {
            get { return displayMember; }
            set
            {
                displayMember = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
