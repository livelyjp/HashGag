//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HashGag.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompetitionTweet
    {
        public int CompetitionTweetID { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<long> TweetID { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
