//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HashGagAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.CompetitionTweets = new HashSet<CompetitionTweet>();
        }
    
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTimeOffset> CreationDate { get; set; }
        public Nullable<System.DateTimeOffset> StartDate { get; set; }
        public Nullable<int> AskedByHashGagUser { get; set; }
        public Nullable<System.DateTimeOffset> EndDate { get; set; }
    
        public virtual ICollection<CompetitionTweet> CompetitionTweets { get; set; }
        public virtual TwitterUser TwitterUser { get; set; }
    }
}
