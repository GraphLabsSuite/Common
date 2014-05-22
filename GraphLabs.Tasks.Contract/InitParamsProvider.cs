using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GraphLabs.Tasks.Contract
{
    /// <summary> Поставщик параметров инициализации задания </summary>
    public class InitParamsProvider : IInitParamsProvider
    {
        public const string PARAMETER_KEY = "data";

        /// <summary> Получить строку с параметрами инициализации </summary>
        public string GetInitParamsString(InitParams parameters)
        {
            string serializedParams;

            var serializer = GetSerializer();
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, parameters);
                serializedParams = Convert.ToBase64String(stream.ToArray());
            }

            return string.Format("{0}={1}", PARAMETER_KEY, serializedParams);
        }

        /// <summary> Разобрать строку с параметрами инициализации </summary>
        public InitParams ParseInitParamsString(string initParamsString)
        {
            var serializer = GetSerializer();
            using (var stream = new MemoryStream(Convert.FromBase64String(initParamsString)))
            {
                return (InitParams)serializer.ReadObject(stream);
            }
        }

        private static DataContractJsonSerializer GetSerializer()
        {
            return new DataContractJsonSerializer(typeof(InitParams));
        }
    }
}
