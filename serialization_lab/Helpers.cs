using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using YamlDotNet.Serialization;

namespace serialization_lab
{
    public class Helpers
    {
        public static string GetElapsedTime(TimeSpan ts)
        {
            return String.Format("{0:00}.{1:00}",
             ts.Seconds, ts.Milliseconds / 10);
        }

        public static void SerializeInCycle(ClassToSerialize c, int countOfSerialization, BinaryFormatter formatter)
        {
            using (Stream stream = new FileStream(String.Format("{0}{1}", Data.pathToSerialize, "binary.binary"), FileMode.Create, FileAccess.Write))
            {
                for (var i = 0; i < countOfSerialization; i++)
                {
                    formatter.Serialize(stream, c);
                }
                stream.Close();
            }
        }

        public static void SerializeInCycle(ClassToSerialize c, int countOfSerialization, JsonSerializer jsonSerializer)
        {
            using (StreamWriter file = File.CreateText(String.Format("{0}{1}", Data.pathToSerialize, "json.json")))
            {
                for (var i = 0; i < countOfSerialization; i++)
                {
                    jsonSerializer.Serialize(file, c);
                }
                file.Close();
            }
        }

        public static void SerializeInCycleYaml(ClassToSerialize c, int countOfSerialization)
        {

            using (StreamWriter streamWriter = new StreamWriter(String.Format("{0}{1}", Data.pathToSerialize, "yaml1.yaml")))
            {
                for (var i = 0; i < countOfSerialization; i++)
                {
                    ISerializer serializer = new SerializerBuilder().Build();
                    serializer.Serialize(streamWriter, c);
                }
                streamWriter.Close();
            }
        }
    }
}
