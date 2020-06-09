using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace serialization_lab.Serializators
{
    public class JSON
    {
        public static void Serialize(ClassToSerialize c,int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Helpers.SerializeInCycle(c, count, new JsonSerializer());
            stopwatch.Stop();
            
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"JSON serialization time: {elapsedTime}");
        }

        public static void DeSerialize(ClassToSerialize c, int countOfSerialization)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            using (StreamReader file = File.OpenText(string.Format("{0}{1}", Data.pathToSerialize, "json.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                ClassToSerialize deserialiseClass = (ClassToSerialize)serializer.Deserialize(file, typeof(ClassToSerialize));
                file.Close();
            }
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"JSON deserialization time: {elapsedTime}");
        }
    }
}
