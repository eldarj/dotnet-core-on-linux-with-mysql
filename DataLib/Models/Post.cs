using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLib.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string IntroImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int Hits { get; set; } = 1;
        public int SharesFacebook { get; set; } = 0;
        public int SharesTwitter { get; set; } = 0;
        public int Likes { get; set; } = 0;

        #region Relations
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Moderator")]
        public int? ModeratorId { get; set; }
        public virtual Moderator Moderator { get; set; }
        #endregion
    }
}
