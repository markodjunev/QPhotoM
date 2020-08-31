namespace QPhotoM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Data.Common.Models;

    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<LikePost>();
        }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<LikePost> Likes { get; set; }
    }
}
