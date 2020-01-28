﻿using System;
using System.Threading.Tasks;
using Pleronet.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Pleronet
{
    partial class MastodonClient
    {
        #region Follow
        /// <summary>
        /// Following an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="reblogs">Whether the followed account’s reblogs will show up in the home timeline</param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Follow(string accountId, bool reblogs = true)
        {
            var data = reblogs ? null : Enumerable.Repeat(new KeyValuePair<string, string>("reblogs", "false"), 1);
            return this.Post<Relationship>($"/api/v1/accounts/{accountId}/follow", data);
        }

        /// <summary>
        /// Unfollowing an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Unfollow(string accountId)
        {
            return this.Post<Relationship>($"/api/v1/accounts/{accountId}/unfollow");
        }

        /// <summary>
        /// Following a remote user
        /// </summary>
        /// <param name="uri">username@domain of the person you want to follow</param>
        /// <returns>Returns the local representation of the followed account, as an Account</returns>
        public Task<Account> Follow(string uri)
        {
            var data = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("uri", uri)
            };
            return this.Post<Account>($"/api/v1/follows", data);
        }
        #endregion

        #region Block
        /// <summary>
        /// Blocking an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Block(string accountId)
        {
            return Post<Relationship>($"/api/v1/accounts/{accountId}/block");
        }

        /// <summary>
        /// Unblocking an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Unblock(string accountId)
        {
            return Post<Relationship>($"/api/v1/accounts/{accountId}/unblock");
        }

        /// <summary>
        /// Fetching a user's blocks
        /// </summary>
        /// <param name="maxId">Get items with ID less than or equal this value</param>
        /// <param name="sinceId">Get items with ID greater than this value</param>
        /// <param name="limit ">Maximum number of items to get (Default 40, Max 80)</param>
        /// <returns>Returns an array of Accounts blocked by the authenticated user</returns>
        public Task<MastodonList<Account>> GetBlocks(string? maxId = null, string? sinceId = null, int? limit = null)
        {
            return GetBlocks(new ArrayOptions() { MaxId = maxId, SinceId = sinceId, Limit = limit });
        }

        /// <summary>
        /// Fetching a user's blocks
        /// </summary>
        /// <param name="options">Define the first and last items to get</param>
        /// <returns>Returns an array of Accounts blocked by the authenticated user</returns>
        public Task<MastodonList<Account>> GetBlocks(ArrayOptions options)
        {
            var url = "/api/v1/blocks";
            if (options != null)
            {
                url += "?" + options.ToQueryString();
            }
            return GetMastodonList<Account>(url);
        }
        #endregion

        #region Mutes
        /// <summary>
        /// Muting an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="notifications">Whether the mute will mute notifications or not</param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Mute(string accountId, bool notifications = true)
        {
            var data = notifications ? null : new[] { new KeyValuePair<string, string>("notifications", "false") };
            return Post<Relationship>($"/api/v1/accounts/{accountId}/mute", data);
        }

        /// <summary>
        /// Unmuting an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the target Account</returns>
        public Task<Relationship> Unmute(string accountId)
        {
            return Post<Relationship>($"/api/v1/accounts/{accountId}/unmute");
        }

        /// <summary>
        /// Fetching a user's mutes
        /// </summary>
        /// <param name="maxId">Get items with ID less than or equal this value</param>
        /// <param name="sinceId">Get items with ID greater than this value</param>
        /// <param name="limit ">Maximum number of items to get (Default 40, Max 80)</param>
        /// <returns>Returns an array of Accounts muted by the authenticated user</returns>
        public Task<MastodonList<Account>> GetMutes(string? maxId = null, string? sinceId = null, int? limit = null)
        {
            return GetMutes(new ArrayOptions() { MaxId = maxId, SinceId = sinceId, Limit = limit });
        }

        /// <summary>
        /// Fetching a user's mutes
        /// </summary>
        /// <param name="options">Define the first and last items to get</param>
        /// <returns>Returns an array of Accounts muted by the authenticated user</returns>
        public Task<MastodonList<Account>> GetMutes(ArrayOptions options)
        {
            var url = "/api/v1/mutes";
            if (options != null)
            {
                url += "?" + options.ToQueryString();
            }
            return GetMastodonList<Account>(url);
        }
        #endregion

        #region Endorsements
        /// <summary>
        /// Getting accounts the user chose to endorse
        /// </summary>
        /// <returns>Returns an array of Accounts endorsed by the authenticated user</returns>
        public Task<MastodonList<Account>> GetEndorsements()
        {
            return GetMastodonList<Account>("/api/v1/endorsements");
        }

        /// <summary>
        /// Endorsing an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the updated Relationships with the target Account</returns>
        public Task<Relationship> Endorse(string accountId)
        {
            return Post<Relationship>($"/api/v1/accounts/{accountId}/pin");
        }

        /// <summary>
        /// Undoing endorse of an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Returns the updated Relationships with the target Account</returns>
        public Task<Relationship> Unendorse(string accountId)
        {
            return Post<Relationship>($"/api/v1/accounts/{accountId}/unpin");
        }
        #endregion

        #region Domain blocks
        /// <summary>
        /// Fetching a user's blocked domains
        /// </summary>
        /// <param name="maxId">Get items with ID less than or equal this value</param>
        /// <param name="sinceId">Get items with ID greater than this value</param>
        /// <param name="limit ">Maximum number of items to get (Default 40, Max 80)</param>
        /// <returns>Returns an array of strings</returns>
        public Task<MastodonList<string>> GetDomainBlocks(string? maxId = null, string? sinceId = null, int? limit = null)
        {
            return GetDomainBlocks(new ArrayOptions() { MaxId = maxId, SinceId = sinceId, Limit = limit });
        }

        /// <summary>
        /// Fetching a user's blocked domains
        /// </summary>
        /// <param name="options">Define the first and last items to get</param>
        /// <returns>Returns an array of strings</returns>
        public Task<MastodonList<string>> GetDomainBlocks(ArrayOptions options)
        {
            var url = "/api/v1/domain_blocks";
            if (options != null)
            {
                url += "?" + options.ToQueryString();
            }
            return GetMastodonList<string>(url);
        }

        /// <summary>
        /// Block a domain
        /// </summary>
        /// <param name="domain">Domain to block</param>
        public Task BlockDomain(string domain)
        {
            var url = "/api/v1/domain_blocks?domain=" + Uri.EscapeUriString(domain);
            return Post(url);
        }

        /// <summary>
        /// Unblock a domain
        /// </summary>
        /// <param name="domain">Domain to block</param>
        public Task UnblockDomain(string domain)
        {
            var url = "/api/v1/domain_blocks?domain=" + Uri.EscapeUriString(domain);
            return Delete(url);
        }

        #endregion

    }
}
