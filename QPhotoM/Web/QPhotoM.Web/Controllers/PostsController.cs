﻿namespace QPhotoM.Web.Controllers
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
    using QPhotoM.Web.ViewModels.Posts.OutputViewModels;

    [Authorize]
    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApplicationUsersService usersService;

        public PostsController(IPostsService postsService, ICloudinaryService cloudinaryService,
            UserManager<ApplicationUser> userManager, IApplicationUsersService usersService)
        {
            this.postsService = postsService;
            this.cloudinaryService = cloudinaryService;
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public IActionResult ById(string id)
        {
            var post = this.postsService.GetById(id);

            if (post == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var result = new PostByIdViewModel
            {
                Id = post.Id,
                Description = post.Description,
                PhotoUrl = post.PhotoUrl,
                CreatedOn = post.CreatedOn,
            };

            result.User = this.usersService.GetUserByIdInPost(post.CreatorId);

            return this.View(result);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
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

        public async Task<IActionResult> Delete(string id)
        {
            var post = this.postsService.GetById(id);
            var user = await this.userManager.GetUserAsync(this.User);

            if (post == null || user.Id != post.CreatorId)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.postsService.DeleteAsync(post);
            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var post = this.postsService.GetById(id);
            var user = await this.userManager.GetUserAsync(this.User);

            if (post == null || user.Id != post.CreatorId)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var model = new PostEditInputModel
            {
                Description = post.Description,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostEditInputModel input, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.EditAsync(input, id);
            return this.RedirectToAction("ById", "Posts", new { area = string.Empty, id = id });
        }
    }
}
