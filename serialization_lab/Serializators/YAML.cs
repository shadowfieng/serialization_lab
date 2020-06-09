using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace serialization_lab.Serializators
{
    public class YAML
    {
        public static void Serialize(ClassToSerialize c, int count)
        {
            Stopwatch stopwatch = new Stopwatch();
            using (StreamWriter streamWriter = new StreamWriter(String.Format("{0}{1}", Data.pathToSerialize, "yaml.yaml")))
            {
                stopwatch.Start();
                Helpers.SerializeInCycleYaml(c, count);
                stopwatch.Stop();
            }

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"YAML serialization time: {elapsedTime}");
        }
        public static void DeSerialize(ClassToSerialize c, int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            var deserialzier = new DeserializerBuilder().Build();

            deserialzier.Deserialize<ClassToSerialize>(File.OpenText(string.Format("{0}{1}", Data.pathToSerialize, "yaml.yaml")));

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"YAML deserialization time: {elapsedTime}");
        }
    }
}
