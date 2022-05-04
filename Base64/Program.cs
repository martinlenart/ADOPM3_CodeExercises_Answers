using System;
using System.Text;
using System.Security.Cryptography;

namespace Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentMessage = "I would like to be an image!";
            byte[] sentBytes = Encoding.Unicode.GetBytes(sentMessage);

            //Encryption
            byte[] hash2 = SHA256.Create().ComputeHash(sentBytes);
            string Base64Hash = Convert.ToBase64String(hash2);

            //Encoding
            string Base64String = Convert.ToBase64String(sentBytes);

            Console.WriteLine("Sent Message");
            Console.WriteLine(sentMessage);
            Console.WriteLine("\nSent Bytes");
            foreach (var item in sentBytes)
            {
                Console.Write($"{item:x2}");
            }
            Console.WriteLine("\n\nSent Base64 string");
            Console.WriteLine(Base64String);

            Console.WriteLine("\n\nSent Base64 Hash string");
            Console.WriteLine(Base64Hash);

            /*
            // Compute hash from string:
            byte[] data = System.Text.Encoding.UTF8.GetBytes("stRhong%pword");
            byte[] hash2 = SHA256.Create().ComputeHash(data);
            */



            //Decoding
            byte[] recievedBytes = Convert.FromBase64String(Base64String);
            Console.WriteLine("\nRecieved Bytes");
            foreach (var item in recievedBytes)
            {
                Console.Write($"{item:x2}");
            }

            Console.WriteLine("\n\nRecieved Base64 string");
            string recievedMessage = Encoding.Unicode.GetString(recievedBytes);
            Console.WriteLine(recievedMessage);

            //Decoding Hash
            byte[] recievedHashBytes = Convert.FromBase64String(Base64Hash);
            Console.WriteLine("\nRecieved Bytes");
            foreach (var item in recievedHashBytes)
            {
                Console.Write($"{item:x2}");
            }

            Console.WriteLine("\n\nRecieved Base64 string");
            string recievedStrangeMessage = Encoding.Unicode.GetString(recievedHashBytes);
            Console.WriteLine(recievedStrangeMessage);

        }
    }
}

//3.    Make a Base64Converter that converts Message content into a base64 string and Serialize. Convert it back to Unicode in Deserialization 
//      Tips:
//      https://docs.microsoft.com/en-us/dotnet/api/system.text.json.utf8jsonreader.trygetbytesfrombase64?view=net-5.0#System_Text_Json_Utf8JsonReader_TryGetBytesFromBase64_System_Byte____
//      https://docs.microsoft.com/en-us/dotnet/api/system.text.json.utf8jsonwriter.writestringvalue?view=net-5.0#System_Text_Json_Utf8JsonWriter_WriteStringValue_System_String_
//
//      Base64 byte[] --> UniCode string:  Encoding.Unicode.GetString()
//      UniCode string --> byte[]: Encoding.Unicode.GetBytes()
//      byte[] --> Base64 string: Convert.ToBase64String()   
