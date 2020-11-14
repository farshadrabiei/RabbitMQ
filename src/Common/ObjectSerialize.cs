using Newtonsoft.Json;
using System;
using System.Text;

namespace Common
{
    public static class ObjectSerialize
    {
        public static byte[] Serialize(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.ASCII.GetBytes(json);
        }

        public static object DeSerialize(this byte[] arrByte, Type type)
        {
            var json = Encoding.Default.GetString(arrByte);
            return JsonConvert.DeserializeObject(json, type);
        }

        public static string DeSerializedText(this byte[] arrByte) 
        {
            return Encoding.Default.GetString(arrByte);

        }
    }
}
