namespace QPhotoM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
