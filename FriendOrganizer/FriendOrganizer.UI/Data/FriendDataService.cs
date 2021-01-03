using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend() { FirstName = "hamada 1", LastName = "el gen 1" };
            yield return new Friend() { FirstName = "hamada 2", LastName = "el gen 2" };
            yield return new Friend() { FirstName = "hamada 3", LastName = "el gen 3" };
            yield return new Friend() { FirstName = "hamada 4", LastName = "el gen 4" };
        }
    }
}
