﻿using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model {
    /// <summary>
    ///     Provides utility methods for XML element classes.
    /// </summary>
    public class XmlHelper {
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        protected IEnumerable<XElement> list { get; set; }

        protected XElement root { get; set; }

        /// <summary>
        ///     Sets and initializes the xml document for parsing using linq to xml.
        /// </summary>
        /// <param name="reader"></param>
        public XmlHelper(XmlReader reader) {
            Contract.Requires(reader != null);
            root = XElement.Load(reader.ReadSubtree());
            list = root.Descendants();
        }

        /// <summary>
        ///     Deserializes an XML rowset using .NETs XmlSerializer.
        /// </summary>
        /// <typeparam name="T">KeyType used for deserialization.</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual RowCollection<T> deserializeRowSet<T>(string name) {
            var reader = getRowSetReader(name);
            if (reader == null) return default(RowCollection<T>);
            reader.ReadToDescendant("rowset");
            var serializer = new XmlSerializer(typeof (RowCollection<T>));
            return (RowCollection<T>) serializer.Deserialize(reader);
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T deserialize<T>(string name) {
            var reader = getReader(name);
            if (reader == null) return default(T);
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(reader);
        }

        /// <summary>
        ///     Gets a XML reader for a regular element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlReader getReader(string name) {
            XElement el = list.FirstOrDefault(x => x.Name == name);
            return el != null ? el.CreateReader() : null;
        }

        /// <summary>
        ///     Gets a XML reader for a rowset element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlReader getRowSetReader(string name) {
            XElement rowset = list.Where(x => x.Name == "rowset").FirstOrDefault(r => r.Attribute("name").Value == name);
            return rowset != null ? rowset.CreateReader() : null;
        }

        public long getLong(string name) {
            return long.Parse(list.First(x => x.Name == name).Value);
        }

        public string getString(string name) {
            return list.First(x => x.Name == name).Value;
        }

        public int getInt(string name) {
            return int.Parse(list.First(x => x.Name == name).Value);
        }

        public decimal getDecimal(string name) {
            return decimal.Parse(list.First(x => x.Name == name).Value, CultureInfo.InvariantCulture);
        }

        public string getStringAttribute(string name) {
            return root.Attribute(name).Value;
        }

        public long getLongAttribute(string name) {
            return long.Parse(root.Attribute(name).Value);
        }

        public int getIntAttribute(string name) {
            return int.Parse(root.Attribute(name).Value);
        }

        public bool getBoolAttribute(string name) {
            return root.Attribute(name).Value != "0" && root.Attribute(name).Value.ToLower() != "false";
        }
    }
}