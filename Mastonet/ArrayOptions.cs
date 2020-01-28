using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pleronet
{
    public class ArrayOptions
    {
        public string? MaxId { get; set; }

        public string? SinceId { get; set; }

        public string? MinId { get; set; }

        public int? Limit { get; set; }

        internal string ToQueryString()
        {
            var query = new Collection<string>();
            if (this.MaxId!=null)
            {
                query.Add("max_id=" + this.MaxId);
            }
            if (this.SinceId != null)
            {
                query.Add("since_id=" + this.SinceId);
            }
            if (this.MinId != null)
            {
                query.Add("min_id=" + this.MinId);
            }
            if (this.Limit.HasValue)
            {
                query.Add("limit=" + this.Limit);
            }
            return string.Join("&", query);
        }
    }
}
