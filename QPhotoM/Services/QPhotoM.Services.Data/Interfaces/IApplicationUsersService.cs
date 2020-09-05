namespace QPhotoM.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using QPhotoM.Web.ViewModels.ApplicationUsers.OutputViewModels;

    public interface IApplicationUsersService
    {
        ApplicationUserPostById GetUserByIdInPost(string id);
    }
}
