using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ZeroTwoTwelve.Extensions
{
    public static class XmlDocumentExtensions
    {
        public static XmlNode CreateElement(this XmlDocument doc, string name, IDictionary<string, string> attributes)
        {
            var element = doc.CreateNode(XmlNodeType.Element, name, "");
            foreach (var attribute in attributes)
            {
                element.Attributes.Append(CreateAttributeWithValue(doc, attribute.Key, attribute.Value));
            }
            return element;
        }

        public static XmlAttribute CreateAttributeWithValue(this XmlDocument doc, string name, string value)
        {
            var attr = doc.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }

    }
}
