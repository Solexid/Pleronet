﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet.Entities
{
    public class Filter
    {
        /// <summary>
        /// ID of the filter
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Keyword or phrase to filter
        /// </summary>
        [JsonProperty("phrase")]
        public string Phrase { get; set; } = string.Empty;

        /// <summary>
        /// Contexts to apply the filter
        /// </summary>
        [JsonProperty("context")]
        public FilterContext Context { get; set; }

        /// <summary>
        /// DateTime when the filter expires if set
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Whether the filter is irreversible
        /// </summary>
        [JsonProperty("irreversible")]
        public bool Irreversible { get; set; }

        /// <summary>
        /// Whether to consider word boundaries when matching
        /// </summary>
        [JsonProperty("whole_word")]
        public bool WholeWord { get; set; }
    }
}
