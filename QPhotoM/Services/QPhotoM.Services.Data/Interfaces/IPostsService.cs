namespace QPhotoM.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using QPhotoM.Data.Models;
    using QPhotoM.Web.ViewModels.Posts.InputModels;

    public interface IPostsService
    {
        Task CreateAsync(string description, string photoUrl, string creatorId);

        Post GetById(string id);

        Task DeleteAsync(Post post);

        Task EditAsync(PostEditInputModel input, string id);
    }
}
