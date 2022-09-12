using ProtectXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProtectingXMLAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ccSecretKey = "P;`oYFN09pyHyo9m0JbQ7AuJV=DEN3EP";
            string ccEncKey = @"ETuaLvqqhnZvU62/pcYZC2xs+p6yXP1hxHKbqjUv0ow=";

                // Encrypts the customer credit card using the secretkey
                // and then uses the secretkey and enckey to return the
                // real credit card number
            //Console.WriteLine(Protector.EncryptString(ccSecretKey, CreditCard));
            Console.WriteLine(Protector.DecryptString(ccSecretKey, ccEncKey));

            //Console.WriteLine(Protector.SaltAndHash(Customer.Password));
            //string saltedHashedPassword = "5Ot7ST/BPeYYtsdSZ9mHIih+RqP/3fT9Fwz88ilNvBg=";

        }

        static void ToXml<C>(C obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xs = new XmlSerializer(typeof(C));
                xs.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public static C FromXml<C>(string path)
        {
            using (StringReader sr = new StringReader(File.ReadAllText(path)))
            {
                XmlSerializer xs = new XmlSerializer(typeof(C));

                return (C)xs.Deserialize(sr);
            }
        }
    }
}