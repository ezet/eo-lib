﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemType.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemType. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemType : CrestResource<ItemType> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemType" /> class.
        /// </summary>
        public ItemType() {
            ContentType = "application/vnd.ccp.eve.ItemType-v3+json";
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "volume")]
        public string Volume { get; set; }
    }
}
