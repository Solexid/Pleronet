﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pleronet.Entities
{
    public class Account
    {
        /// <summary>
        /// The ID of the account
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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

        /// <summary>
        /// The account's display name
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Boolean for when the account cannot be followed without waiting for approval first
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// The time the account was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The number of followers for the account
        /// </summary>
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// The number of accounts the given account is following
        /// </summary>
        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        /// <summary>
        /// The number of statuses the account has made
        /// </summary>
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }
        
        /// <summary>
        /// Biography of user
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// URL of the user's profile page (can be remote)
        /// </summary>
        [JsonProperty("url")]
        public string ProfileUrl { get; set; } = string.Empty;

        /// <summary>
        /// URL to the avatar image
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; } = string.Empty;

        /// <summary>
        /// URL to the avatar static image (gif)
        /// </summary>
        [JsonProperty("avatar_static")]
        public string StaticAvatarUrl { get; set; } = string.Empty;

        /// <summary>
        /// URL to the header image
        /// </summary>
        [JsonProperty("header")]
        public string HeaderUrl { get; set; } = string.Empty;

        /// <summary>
        /// URL to the header image
        /// </summary>
        [JsonProperty("header_static")]
        public string StaticHeaderUrl { get; set; } = string.Empty;

        /// <summary>
        /// Emojis used in the account info
        /// </summary>
        [JsonProperty("emojis")]
        public IEnumerable<Emoji> Emojis { get; set; } = Enumerable.Empty<Emoji>();

        /// <summary>
        /// If moved, the new account for the account
        /// </summary>
        [JsonProperty("moved")]
        public Account? Moved { get; set; }

        /// <summary>
        /// The custom fields of the account
        /// </summary>
        [JsonProperty("fields")]
        public IEnumerable<AccountField>? Fields { get; set; }

        /// <summary>
        /// Whether the account is a bot
        /// </summary>
        [JsonProperty("bot")]
        public bool? Bot { get; set; }

        /// <summary>
        /// Source of the authorized account's profile (returned only from *_credentials endpoints)
        /// </summary>
        [JsonProperty("source")]
        public AccountSource? Source { get; set; }
    }

    public class AccountField
    {
        /// <summary>
        /// The name of the field
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The value of the field (HTML)
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The datetime when the account is verified if the field value is a link
        /// </summary>
        [JsonProperty("verified_at")]
        public DateTime? VerifiedAt { get; set; }
    }
    
    public class AccountSource
    {
        /// <summary>
        /// The default visibility for the account
        /// </summary>
        [JsonProperty("privacy")]
        public Visibility? Privacy { get; set; }

        /// <summary>
        /// The default media sensitiveness setting for the account
        /// </summary>
        [JsonProperty("sensitive")]
        public bool? Sensitive { get; set; }

        /// <summary>
        /// The language setting for the account (ISO6391)
        /// </summary>
        [JsonProperty("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Biography of the user (in plain text)
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// The custom fields of the account (in plain text)
        /// </summary>
        [JsonProperty("fields")]
        public IEnumerable<AccountField> Fields { get; set; } = Enumerable.Empty<AccountField>();
    }
}
