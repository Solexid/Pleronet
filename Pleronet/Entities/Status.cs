using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pleronet.Entities
{
    public class Status
    {
        /// <summary>
        /// The ID of the status
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A Fediverse-unique resource ID
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; } = string.Empty;

        /// <summary>
        /// URL to the status page (can be remote)
        /// </summary>
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Pleroma object
        /// </summary>
        [JsonProperty("pleroma")]
        public PleromaStatus Pleroma { get; set; } = new PleromaStatus();


        /// <summary>
        /// The Account which posted the status
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; } = new Account();

        /// <summary>
        /// null or the ID of the status it replies to
        /// </summary>
        [JsonProperty("in_reply_to_id")]
        public string? InReplyToId { get; set; }

        /// <summary>
        /// null or the ID of the account it replies to
        /// </summary>
        [JsonProperty("in_reply_to_account_id")]
        public string? InReplyToAccountId { get; set; }

        /// <summary>
        /// null or the reblogged Status
        /// </summary>
        [JsonProperty("reblog")]
        public Status? Reblog { get; set; }

        /// <summary>
        /// Body of the status; this will contain HTML (remote HTML already sanitized)
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The time the status was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// An array of Emojis
        /// </summary>
        [JsonProperty("emojis")]
        public IEnumerable<Emoji> Emojis { get; set; } = Enumerable.Empty<Emoji>();

        /// <summary>
        /// The number of replies for the status
        /// </summary>
        [JsonProperty("replies_count")]
        public int RepliesCount { get; set; }

        /// <summary>
        /// The number of reblogs for the status
        /// </summary>
        [JsonProperty("reblogs_count")]
        public int ReblogCount { get; set; }

        /// <summary>
        /// The number of favourites for the status
        /// </summary>
        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Whether the authenticated user has reblogged the status
        /// </summary>
        [JsonProperty("reblogged")]
        public bool Reblogged { get; set; }

        /// <summary>
        /// Whether the authenticated user has favourited the status
        /// </summary>
        [JsonProperty("favourited")]
        public bool Favourited { get; set; }

        /// <summary>
        /// Whether the authenticated user has muted the conversation this status from
        /// </summary>
        [JsonProperty("muted")]
        public bool Muted { get; set; }

        /// <summary>
        /// Whether media attachments should be hidden by default
        /// </summary>
        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        /// <summary>
        /// If not empty, warning text that should be displayed before the actual content
        /// </summary>
        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; } = string.Empty;

        /// <summary>
        /// One of: public, unlisted, private, direct
        /// </summary>
        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }

        /// <summary>
        /// An array of Attachments
        /// </summary>
        [JsonProperty("media_attachments")]
        public IEnumerable<Attachment> MediaAttachments { get; set; } = Enumerable.Empty<Attachment>();

        /// <summary>
        /// An array of Mentions
        /// </summary>
        [JsonProperty("mentions")]
        public IEnumerable<Mention> Mentions { get; set; } = Enumerable.Empty<Mention>();

        /// <summary>
        /// An array of Tags
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; } = Enumerable.Empty<Tag>();

        /// <summary>
        /// Attached card, if any
        /// </summary>
        [JsonProperty("card")]
        public Card Card { get; set; }

        /// <summary>
        /// Attached poll, if any
        /// </summary>
        [JsonProperty("poll")]
        public Poll Poll { get; set; }

        /// <summary>
        /// Application from which the status was posted
        /// </summary>
        [JsonProperty("application")]
        public Application Application { get; set; } = new Application();

        /// <summary>
        /// The detected language for the status, if detected
        /// </summary>
        [JsonProperty("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Whether the status is pinned
        /// </summary>
        [JsonProperty("pinned")]
        public bool? Pinned { get; set; }
    }
    public class PleromaStatus
    {




        /// <summary>
        /// True if the post was made on the local instance
        /// </summary>
        [JsonProperty("local")]
        public bool Local { get; set; }

        /// <summary>
        /// ID of the AP context the status is associated with (if any)
        /// </summary>
        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; } = string.Empty;

        /// <summary>
        /// ID of the Mastodon direct message conversation the status is associated with (if any)
        /// </summary>
        [JsonProperty("direct_conversation_id")]
        public string DirectConversationId { get; set; } = string.Empty;

        /// <summary>
        /// True if the thread the post belongs to is muted
        /// </summary>
        [JsonProperty("thread_muted")]
        public bool ThreadMuted { get; set; }

        /// <summary>
        /// List of emoji reactions (if any)
        /// </summary>
        [JsonProperty("emoji_reactions")]
        public IEnumerable<PleromaEmojiReactions> EmojiReactions { get; set; } = Enumerable.Empty<PleromaEmojiReactions>();



    }
    public class PleromaEmojiReactions
    {
        /// <summary>
        /// Emoji
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Count of reactions
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Reaction by you?
        /// </summary>
        [JsonProperty("me")]
        public bool Me { get; set; }
    }




}
