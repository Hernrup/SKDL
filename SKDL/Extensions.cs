using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SKDL
{
    public static class Extensions
    {
        public static string serialize<T>(this T toSerialize)
        {
            return DataHandler.serialize(toSerialize);
        }
    }


}
