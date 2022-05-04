using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(0);

            //Random byte[]
            byte[] image = new byte[10_000_000];
//            rand.NextBytes(image);

            for (int i = 0; i < image.Length; i++)
            {
                image[i] = 236;
            }

            //Uncompressed
            using (Stream s = new MemoryStream())
            //            using (Stream s = File.Create(fname("Example4_13_uncompressedbytes.bin")))
            using (BinaryWriter w = new BinaryWriter(s))
            {
                w.Write(image);
                Console.WriteLine(s.Length);
            }
            //            Console.WriteLine(new FileInfo(fname("Example4_13_uncompressedbytes.bin")).Length);

            using (Stream s = new MemoryStream())
            //            using (Stream s = File.Create(fname("Example4_13_compressedbytes.bin")))
            //            using (Stream ds = new DeflateStream(s, CompressionMode.Compress))
            using (Stream ds = new GZipStream(s, CompressionMode.Compress))
            //            using (Stream ds = new BrotliStream(s, CompressionMode.Compress))
            using (BinaryWriter w = new BinaryWriter(ds))
            {
                w.Write(image);
                Console.WriteLine(s.Length);
            }

            Console.WriteLine(new FileInfo(fname("Example4_13_compressedbytes.bin")).Length);

            using (Stream s = new MemoryStream())
//            using (Stream s = File.OpenRead(fname("Example4_13_compressedbytes.bin")))
//            using (Stream ds = new DeflateStream(s, CompressionMode.Decompress))
            using (Stream ds = new GZipStream(s, CompressionMode.Decompress))
//            using (Stream ds = new BrotliStream(s, CompressionMode.Decompress))
            using (BinaryReader r = new BinaryReader(ds))
            {
                byte[] imageRead = r.ReadBytes(image.Length);
                Console.Write(imageRead.Length);
            }

            static string fname(string name)
            {
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "AOOP2", "Examples");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return Path.Combine(documentPath, name);
            }
        }

        //Exercises:
        //1.    Modify above code to compress using GZip and BrotliStream algorithms
        //2.    Modify code to compress a randomly initialized byte array of 10k bytes
        //3.    Modify code to compress in Memory using a MemoryStream
    }
}
