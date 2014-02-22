﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Account;

namespace eZet.Eve.EoLib.Entity {
    public class CharacterKey : ApiKey {

        private ReadOnlyCollection<Character> _characters;

        /// <summary>
        /// A list of valid character ids for this key.
        /// </summary>
        public ReadOnlyCollection<Character> Characters {
            get {
                if (_characters == null)
                    lazyLoad();
                return _characters;
            }
            private set { _characters = value; }
        }

        public CharacterKey(long keyId, string vCode) : base(keyId, vCode) {
        }

        /// <summary>
        /// Returns basic account information including when the subscription lapses, total play time in minutes, total times logged on and date of account creation.
        /// <para></para>
        /// In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountStatus> GetAccountStatus() {
            const int mask = 33554432;
            const string uri = "/account/AccountStatus.xml.aspx";
            return request(new AccountStatus(), uri, this);
        }

        /// <summary>
        /// Returns basic account information including when the subscription lapses, total play time in minutes, total times logged on and date of account creation.
        /// In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<XmlResponse<AccountStatus>> GetAccountStatusAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetAccountStatus());
            return result;
        }

        protected override void load(XmlResponse<ApiKeyInfo> info ) {
            base.load(info);
            var list = info.Result.Key.Characters.Select(c => new Character(this, c.CharacterId, c.CharacterName)).ToList();
            Characters = list.AsReadOnly();
        }

        private void lazyLoad() {
            var info = GetApiKeyInfo();
            load(info);
        }
    }
}
