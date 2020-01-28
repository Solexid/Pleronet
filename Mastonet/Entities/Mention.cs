using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet.Entities
{
    public class Mention
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// URL of user's profile (can be remote)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// The username of the account
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Equals username for local users, includes @domain for remote ones
        /// </summary>
        [JsonProperty("acct")]
        public string AccountName { get; set; } = string.Empty;

    }
}
