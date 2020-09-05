namespace QPhotoM.Web.ViewModels.Posts.OutputViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ganss.XSS;
    using QPhotoM.Web.ViewModels.ApplicationUsers.OutputViewModels;

    public class PostByIdViewModel
    {
        public string Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public DateTime CreatedOn { get; set; }

        public ApplicationUserPostById User { get; set; }
    }
}
