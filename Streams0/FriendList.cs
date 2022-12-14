using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Streams0
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


        /// <summary>
        /// Write the text representation of the instance of FriendList to a text file
        /// </summary>
        /// <param name="txtFileName">The text file to write to</param>
        /// <returns></returns>
        public string WriteToDisk(string txtFileName)
        {
            using (FileStream fs = File.Create(fname(txtFileName)))
            using (TextWriter writer = new StreamWriter(fs))
            {
                writer.Write(this.ToString());
            }
            return fname(txtFileName);
        }

        /// <summary>
        /// Write a ziped compressed of file the text representation of the instance of FriendList
        /// </summary>
        /// <param name="zipFileName">Zip file to write the compressed content to</param>
        /// <returns></returns>
        public string WriteToDiskCompressed(string zipFileName)
        {
            using (FileStream fs = File.Create(fname(zipFileName)))
            using (Stream ds = new GZipStream(fs, CompressionMode.Compress))
            using (TextWriter writer = new StreamWriter(ds))
            {
                writer.Write(this.ToString());
            }

            return fname(zipFileName);
        }

        /// <summary>
        /// Uncompresses the zipFile and writes the uncompressed content to a texfile
        /// </summary>
        /// <param name="zipFileName">Zip file to read and uncompress</param>
        /// <param name="txtFileName">Text file to write the uncompressed content</param>
        /// <returns></returns>
        public string UncompressToDisk(string zipFileName, string txtFileName)
        {
            //read from stream
            using (Stream s = File.OpenRead(fname(zipFileName)))
            using (Stream ds = new GZipStream(s, CompressionMode.Decompress))
            using (TextReader r = new StreamReader(ds))

            //write to stream
            using (FileStream fs = File.Create(fname(txtFileName)))
            using (TextWriter writer = new StreamWriter(fs))
            {
                var sReadback = r.ReadToEnd();
                writer.Write(sReadback);
            }
            return fname(txtFileName);
        }


        static string fname(string name)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            documentPath = Path.Combine(documentPath, "ADOP", "Streams");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return Path.Combine(documentPath, name);
        }
    }
}
