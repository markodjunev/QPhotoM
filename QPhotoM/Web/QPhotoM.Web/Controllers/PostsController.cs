namespace QPhotoM.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using QPhotoM.Data.Models;
    using QPhotoM.Services.Data.Interfaces;
    using QPhotoM.Web.ViewModels.Posts.InputModels;

    [Authorize]
    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ICloudinaryService cloudinaryService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.cloudinaryService = cloudinaryService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var photoUrl = await this.cloudinaryService.UploadPictureAsync(input.PhotoUrl, Guid.NewGuid().ToString());

            await this.postsService.CreateAsync(input.Description, photoUrl, user.Id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
