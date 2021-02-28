using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace Fractals
{
    public static class Extensions
    {
        public static string ToXml(this object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using(StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
        public static T FromXml<T>(this string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(StringReader reader = new StringReader(data))
            {
                object obj = serializer.Deserialize(reader);
                return (T)obj;
            }
        
        }
        public static bool ContainsFiles(this string fpath)
        {
            try
            {
                return Directory.EnumerateFileSystemEntries(fpath).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string HashString(this string Raw)
        {
            string HashedString;
            using (SHA256Managed hasher = new SHA256Managed())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Raw);
                byte[] HashedBytes = hasher.ComputeHash(bytes);

                HashedString = String.Empty;
                foreach (byte x in HashedBytes)
                {
                    HashedString += String.Format("{0:x2}", x);
                }
            }
            return HashedString;
        }
    }
}
