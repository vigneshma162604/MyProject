using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetBL.Models
{
    public class TweetModel
    {
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

    }
}