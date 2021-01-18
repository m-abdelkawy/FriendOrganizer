using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FriendOrganizer.UI.Wrapper
{
    public class NotifyDataErrorInfoBase: ViewModelBase, INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> _errorByPropName = new Dictionary<string, List<string>>();

        public bool HasErrors
        {
            get
            {
                return _errorByPropName.Any();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorByPropName.ContainsKey(propertyName)
                ? _errorByPropName[propertyName]
                : null;
        }

        //Helper method to raise ErrorChangedEvent
        protected virtual void OnErrorChanged(/*[CallerMemberName]*/ string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errorByPropName.ContainsKey(propertyName))
            {
                _errorByPropName[propertyName] = new List<string>();
            }
            if (!_errorByPropName[propertyName].Contains(error))
            {
                _errorByPropName[propertyName].Add(error);
                OnErrorChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertName)
        {
            if (_errorByPropName.ContainsKey(propertName))
            {
                _errorByPropName.Remove(propertName);
                OnErrorChanged(propertName);
            }
        }
    }
}
