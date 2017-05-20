using System;
using System.Xml;
using System.Xml.Serialization;

namespace hwcconfig
{
    internal static class ParsingHelpers
    {
        /// <summary>
        /// Parser for the Application Pool configs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        private static T ParseXML<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }
    }
}
