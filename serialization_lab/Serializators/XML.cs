using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace serialization_lab
{
    public class XML
    {
        public static void Serialize()
        {
            ClassToSerialize c = new ClassToSerialize();

            XmlSerializer formatter = new XmlSerializer(typeof(ClassToSerialize));

            using (FileStream fs = new FileStream(String.Format("{0}{1}", Data.pathToSerialize, "xml.xml"), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, c);
                Console.WriteLine("Объект сериализован");
                fs.Close();
            }
        }
    }
}
