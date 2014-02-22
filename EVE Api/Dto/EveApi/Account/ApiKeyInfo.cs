﻿using System;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class ApiKeyInfo : XmlElement {

        [XmlElement("key")]
        public ApiKeyData Key { get; set; }

    }

    public class ApiKeyData {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters { get; set; }

        [XmlAttribute("accessMask")]
        public int AccessMask { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlIgnore]
        public DateTime ExpireDate { get; private set; }

        [XmlAttribute("expires")]
        public string ExpireDateAsString {
            get { return ExpireDate.ToString(XmlElement.DateFormat); }
            set {
                ExpireDate = value == "" ? DateTime.MinValue : DateTime.ParseExact(value, XmlElement.DateFormat, null);
            }
        }

    }
}