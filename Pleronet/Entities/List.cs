using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet.Entities
{
    public class List
    {
        /// <summary>
        /// ID of the list
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Title of the list
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;
    }
}
