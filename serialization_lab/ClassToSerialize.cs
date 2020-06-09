using System;
using System.Collections.Generic;
using System.Text;

namespace serialization_lab
{
    [Serializable]
    public class ClassToSerialize
    {
        public string Str { get; set; }
        public string[] StrArr { get; set; }
        public Dictionary<string, string> Dict { get; set; }
        public int Integer { get; set; }
        public double Doubled { get; set; }

        public ClassToSerialize()
        {
            Str = Data.str;
            StrArr = Data.strArr;
            Dict = Data.dict;
            Integer = Data.integer;
            Doubled = Data.doubled;
        }

    }
}
