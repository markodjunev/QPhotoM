namespace QPhotoM.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task CreateAsync(string description, string photoUrl, string creatorId);
    }
}
