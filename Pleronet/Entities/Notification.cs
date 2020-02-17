using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet.Entities
{
    public class Notification
    {
        /// <summary>
        /// The notification ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// One of: "mention", "reblog", "favourite", "follow"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The time the notification was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }



        /// <summary>
        /// Pleroma object
        /// </summary>
        [JsonProperty("pleroma")]
        public PleromaNotification Pleroma { get; set; } = new PleromaNotification();



        /// <summary>
        /// The Account sending the notification to the user
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; } = new Account();

        /// <summary>
        /// The Status associated with the notification, if applicible
        /// </summary>
        [JsonProperty("status")]
        public Status? Status { get; set; }
    }
    public class PleromaNotification
    {




        /// <summary>
        /// Seen notification status
        /// </summary>
        [JsonProperty("is_seen")]
        public bool IsSeen { get; set; }





    }



}
