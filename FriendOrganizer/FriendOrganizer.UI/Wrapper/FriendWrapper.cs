using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id { get { return GetValue<int>(); } }



        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }



        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);
        //    switch (propertyName)
        //    {
        //        case nameof(FirstName):
        //            if (string.Equals(FirstName.Trim(), "Robot", StringComparison.OrdinalIgnoreCase))
        //            {
        //                AddError(propertyName, "Robots are not valid friends!");
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName.Trim(), "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid friends!";
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
