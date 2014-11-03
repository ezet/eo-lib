﻿// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveWhoCorporationMembers.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveWhoCorporationMembers.
    /// </summary>
    [DataContract]
    public class EveWhoCorporationMembers {
        /// <summary>
        /// Gets or sets the corporation identifier.
        /// </summary>
        /// <value>The corporation identifier.</value>
        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the member count.
        /// </summary>
        /// <value>The member count.</value>
        [DataMember(Name = "memberCount")]
        public int MemberCount { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        [DataMember(Name = "characters")]
        public IList<EveWhoMember> Members { get; set; }
    }
}