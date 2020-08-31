namespace QPhotoM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Data.Common.Models;

    public class LikePost : BaseDeletableModel<int>
    {
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
