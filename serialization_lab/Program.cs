using serialization_lab.Serializators;
using System;

namespace serialization_lab
{
    class Program
    {
        static void Main(string[] args)
        {

            ClassToSerialize c = new ClassToSerialize();
            Console.WriteLine("Введите количество циклов сериализации/десериализации: ");
            var count = int.Parse(Console.ReadLine());

            Binary.Serialize(c, count);
            Binary.DeSerialize(c, count);
            JSON.Serialize(c, count);
            JSON.DeSerialize(c, count);
            YAML.Serialize(c, count);
            YAML.DeSerialize(c, count);
        }
    }
}
