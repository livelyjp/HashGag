﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterToken;
using TweetinCore.Interfaces.TwitterToken;
using Twitter_Engine.Models;

namespace Twitter_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            FetchTweets();
        }

        public static void FetchTweets()
        {
            TwitterFetcher fetcher = new TwitterFetcher();
            TweetManager cTweet = new TweetManager(fetcher);
        }
    }
}
