﻿using Pleronet.Entities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Pleronet
{
    public abstract class TimelineStreaming
    {
        protected readonly StreamingType streamingType;
        protected readonly string? param;
        protected readonly string? accessToken;

        public event EventHandler<StreamUpdateEventArgs>? OnUpdate;
        public event EventHandler<StreamNotificationEventArgs>? OnNotification;
        public event EventHandler<StreamDeleteEventArgs>? OnDelete;
        public event EventHandler<StreamFiltersChangedEventArgs>? OnFiltersChanged;
        public event EventHandler<StreamConversationEvenTargs>? OnConversation;

        protected TimelineStreaming(StreamingType type, string? param, string? accessToken)
        {
            this.streamingType = type;
            this.param = param;
            this.accessToken = accessToken;
        }

        public abstract Task Start();
        public abstract void Stop();

        protected void SendEvent(string eventName, string data)
        {
            switch (eventName)
            {
                case "update":
                    var status = JsonConvert.DeserializeObject<Status>(data);
                    OnUpdate?.Invoke(this, new StreamUpdateEventArgs(status));
                    break;
                case "notification":
                    var notification = JsonConvert.DeserializeObject<Notification>(data);
                    OnNotification?.Invoke(this, new StreamNotificationEventArgs(notification));
                    break;
                case "delete":
                    var statusId = (data);
                    OnDelete?.Invoke(this, new StreamDeleteEventArgs(statusId));
                    break;
                case "filters_changed":
                    OnFiltersChanged?.Invoke(this, new StreamFiltersChangedEventArgs());
                    break;
                case "conversation":
                    var conversation = JsonConvert.DeserializeObject<Conversation>(data);
                    OnConversation?.Invoke(this, new StreamConversationEvenTargs(conversation));
                    break;
            }
        }

    }
}