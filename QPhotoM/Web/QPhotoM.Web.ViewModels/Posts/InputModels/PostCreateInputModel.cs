namespace QPhotoM.Web.ViewModels.Posts.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class PostCreateInputModel
    {
        public string Description { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public IFormFile PhotoUrl { get; set; }
    }
}
