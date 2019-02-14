﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetBL.Models
{
    public class PersonModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
        public bool Active { get; set; }
    }
}