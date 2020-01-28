﻿using Pleronet.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet
{
    public class StreamUpdateEventArgs : EventArgs
    {
        public StreamUpdateEventArgs(Status status)
        {
            Status = status;
        }

        public Status Status { get; set; }
    }

    public class StreamNotificationEventArgs : EventArgs
    {
        public StreamNotificationEventArgs(Notification notification)
        {
            this.Notification = notification;
        }

        public Notification Notification { get; set; }
    }

    public class StreamDeleteEventArgs : EventArgs
    {
        public StreamDeleteEventArgs(string statusId)
        {
            statusId = statusId;
        }

        public string statusId { get; set; }
    }

    public class StreamFiltersChangedEventArgs : EventArgs
    {
    }

    public class StreamConversationEvenTargs : EventArgs
    {
        public StreamConversationEvenTargs(Conversation conversation)
        {
            Conversation = conversation;
        }

        public Conversation Conversation { get; set; }
    }
}
