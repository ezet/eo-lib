﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IndustryTeamCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace eZet.EveLib.EveCrestModule.Models.Resources.Industry {
    /// <summary>
    ///     Represents a CREST /industry/teams/ response
    /// </summary>
    public sealed class IndustryTeamCollection : CollectionResource<IndustryTeamCollection, IndustryTeam> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndustryTeamCollection" /> class.
        /// </summary>
        public IndustryTeamCollection() {
            ContentType = "application/vnd.ccp.eve.IndustryTeamCollection-v1+json";
        }
    }
}