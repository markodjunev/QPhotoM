namespace QPhotoM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Data.Common.Models;

    public class Search : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
