using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/*
* Serialization of persisting the state of the object to a storage device instead of contents of the object. The object state includes the data as well as metadata of the object. metadata includes classinfo, members of the class, its namespace, assembly info and many more to make it an object. 
* .NET has 3 types of serialization: Xml, Binary and SOAP. SOAP is used by web services. 
* Binary is used for data that is used only within the Windows OS.
* Xml is used for data that has to be used in a multi platform. 
* For any serialization U need 3 points:
* What to serialize: objects of any .NET Class that has an attribute called Serializable. 
* How to serialize: the format of serialization: Binary vs. XML vs. SOAP
* Where to serialize: memory, file, process and so forth.
* BinaryFormater class is used to serialize the data in Binary format
* XmlSerializer class is used to serialize the data in Xml Format
* Webservices are used to serialize the data as SOAP...
* XmlSerialization does not need Serializable attribute. It should have its class declared as public. 
* Serialization process will not have appending ability, it either writes the whole object or nothing. 
*/
namespace Frameworks
{
    [Serializable]//Attributes are optional properties injected into the units for some encapsulated operation. Serializable attribute will inject some extra code for UR class so that its objects can be serialized.  
    public class Simple
    {
        public int SimpleID { get; set; }
        public long SimpleNo { get; set; }
    }

    class Serialization
    {
        static void Main(string[] args)
        {
            //xmlSerialization();
            //XmlDeserializationEvents();
            //binarySerialization();
            binaryDeserialization();
        }

        private static void binaryDeserialization()
        {
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Simple.Bin", FileMode.Open, FileAccess.Read);
            Simple cls = fm.Deserialize(fs) as Simple;
            fs.Close();
            Console.WriteLine(cls.SimpleID + " and " + cls.SimpleNo);
        }

        private static void binarySerialization()
        {
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Simple.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            Simple cls = new Simple { SimpleID = MyConsole.GetNumber("Enter some no"), SimpleNo = long.Parse(MyConsole.GetString("Enter some long no")) };
            fm.Serialize(fs, cls);
            fs.Close();

        }

        private static void XmlDeserializationEvents()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Simple));
            FileStream fs = new FileStream("Simple.xml", FileMode.Open, FileAccess.Read);
            Simple simple = serializer.Deserialize(fs) as Simple;
            Console.WriteLine(simple.SimpleID + " and " + simple.SimpleNo);
            fs.Close();
        }

        private static void xmlSerialization()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Simple));
            Simple simple = new Simple { SimpleID = 123, SimpleNo = 234432424566 };
            FileStream fs = new FileStream("Simple.xml", FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(fs, simple);
            fs.Close();
        }
    }
}
