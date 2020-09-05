namespace QPhotoM.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using QPhotoM.Data.Models;

    public interface IPostsService
    {
        Task CreateAsync(string description, string photoUrl, string creatorId);

        Post GetById(string id);
    }
}
