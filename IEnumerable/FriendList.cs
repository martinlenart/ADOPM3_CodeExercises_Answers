using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IEnumerable
{
    public class FriendList : IEnumerable<Friend>
    {

        private  List<Friend> myFriends = new List<Friend>();
        public Friend this[int idx]=> myFriends[idx];

        #region Exercise 1
        public int Count => myFriends.Count;

        public IEnumerator<Friend> GetEnumerator()
        {
            foreach (var item in myFriends)
            {
                yield return item;
            }
        }
        IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        public override string ToString()
        {
            string sRet = "";
            foreach (var item in myFriends)
            {
                sRet += item.ToString() + "\n";
            }
            return sRet;
        }

 
        public static class Factory
        {
            public static FriendList CreateRandom(int NrOfItems)
            {

                var myList = new FriendList();
                for (int i = 0; i < NrOfItems; i++)
                {
                    var afriend = Friend.Factory.CreateRandom();
                    myList.myFriends.Add(afriend);
                }
                return myList;
            }
        }
    }
}
