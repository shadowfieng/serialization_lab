using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serialization_lab
{
    public class Binary
    {
        public static void Serialize(ClassToSerialize c, int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            var formatter = new BinaryFormatter();

            stopwatch.Start();
            Helpers.SerializeInCycle(c, count, formatter);
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"Binary serialization time: {elapsedTime}");
        }

        public static void DeSerialize(ClassToSerialize c, int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            var formatter = new BinaryFormatter();

            stopwatch.Start();

            FileStream fs = new FileStream(String.Format("{0}{1}", Data.pathToSerialize, "binary.binary"), FileMode.Open);

            // Deserialize the hashtable from the file and
            // assign the reference to the local variable.
            var d = (ClassToSerialize)formatter.Deserialize(fs);
            stopwatch.Stop();
            fs.Close();

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = Helpers.GetElapsedTime(ts);

            Console.WriteLine($"Binary deserialization time: {elapsedTime}");


        }
    }
}
