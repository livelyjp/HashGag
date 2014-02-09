﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using HashGag.Models;
using HashGag.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace HashGag.Controllers
{
    public class CompetitionController : Controller
    {
        //
        // GET: /Competition/
        public ActionResult Index()
        {
            //List<Question> questionList = new List<Question>();

            //Question sdf = new Question();

            //sdf.Text = "New Question";
            //sdf.TwitterUser = new TwitterUser();
            //sdf.TwitterUser.ProfileImageURL = "https://pbs.twimg.com/profile_images/3685227674/67c501ba4eb74c8b7426f1109b38e70a_bigger.jpeg";
            //sdf.EndDate = new DateTimeOffset(DateTime.Now);

            //questionList.Add(sdf);
            //Question sdfa = new Question();
            //sdfa.Text = "New Question Two";
            //sdfa.TwitterUser = new TwitterUser();
            //sdfa.TwitterUser.ProfileImageURL = "https://pbs.twimg.com/profile_images/3685227674/67c501ba4eb74c8b7426f1109b38e70a_bigger.jpeg";
            //sdfa.EndDate = new DateTimeOffset(DateTime.Now);
            //questionList.Add(sdfa);
            //Question sdsf = new Question();
            //sdsf.Text = "New Question Three";
            //sdsf.TwitterUser = new TwitterUser();
            //sdsf.TwitterUser.ProfileImageURL = "https://pbs.twimg.com/profile_images/3685227674/67c501ba4eb74c8b7426f1109b38e70a_bigger.jpeg";
            //sdsf.EndDate = new DateTimeOffset(DateTime.Now);
            //questionList.Add(sdsf);
            //Question sddf = new Question();
            //sddf.Text = "New Question Four";
            //sddf.TwitterUser = new TwitterUser();
            //sddf.TwitterUser.ProfileImageURL = "https://pbs.twimg.com/profile_images/3685227674/67c501ba4eb74c8b7426f1109b38e70a_bigger.jpeg";
            //sddf.EndDate = new DateTimeOffset(DateTime.Now);
            //questionList.Add(sddf);
            //Question sfdf = new Question();
            //sfdf.Text = "New Question Five";
            //sfdf.TwitterUser = new TwitterUser();
            //sfdf.TwitterUser.ProfileImageURL = "https://pbs.twimg.com/profile_images/3685227674/67c501ba4eb74c8b7426f1109b38e70a_bigger.jpeg";
            //sfdf.EndDate = new DateTimeOffset(DateTime.Now);
            //questionList.Add(sfdf);

            //CompetitionViewModel model = new CompetitionViewModel(questionList, questionList, questionList);
            CompetitionViewModel model = new CompetitionViewModel(null, null, null);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            hashgagEntities db = new hashgagEntities();

            var query = from q in db.Questions
                        join cpt in db.CompetitionTweets on q.QuestionID equals cpt.QuestionID
                        join t in db.Tweets on cpt.TweetID equals t.TweetID
                        join tu in db.TwitterUsers on t.TwitterUserID equals tu.TwitterID
                        where q.QuestionID == id

                        select new { q, t, tu, cpt };

            List<CompTweetModel> list = new List<CompTweetModel>();

            foreach (var item in query)
            {
                Tweet tweet = item.t;
                TwitterUser tUser = item.tu;
                
                CompTweetModel cTUser = new CompTweetModel(tweet, tUser);

                list.Add(cTUser);
            }

            List<CompTweetModel> tempOrderedTweets = new List<CompTweetModel>();

            tempOrderedTweets.AddRange(from atweet in list orderby atweet.tweet.RetweetCount descending select atweet);
           
            CompetitionViewModel cmodel = new CompetitionViewModel(tempOrderedTweets, list, list);
            return View("Index", cmodel);
        }
	}
}