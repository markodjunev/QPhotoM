namespace QPhotoM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Data.Common.Models;

    public class Follow : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string FollowedUserId { get; set; }

        public virtual ApplicationUser FollowedUser { get; set; }
    }
}
