using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization0
{
    public class FriendList
    {
        public  List<Friend> myFriends = new List<Friend>();
        public Friend this[int idx]=> myFriends[idx];

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

        public void SerializeXml(string xmlFileName)
        {
            var xs = new XmlSerializer(typeof(FriendList));

            using (Stream s = File.Create(fname(xmlFileName)))
            {
                xs.Serialize(s, this);
            }
        }
        public static FriendList DeSerializeXml(string xmlFileName)
        {
            var xs = new XmlSerializer(typeof(FriendList));
            FriendList flist;
            using (Stream s = File.OpenRead(fname(xmlFileName)))
            {
                flist = (FriendList)xs.Deserialize(s);
                return flist;
            }
        }

        static string fname(string name)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            documentPath = Path.Combine(documentPath, "ADOP", "Serialization");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return Path.Combine(documentPath, name);
        }
    }
}
