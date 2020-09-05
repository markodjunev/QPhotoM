namespace QPhotoM.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using QPhotoM.Data.Common.Repositories;
    using QPhotoM.Data.Models;
    using QPhotoM.Services.Data.Interfaces;
    using QPhotoM.Web.ViewModels.ApplicationUsers.OutputViewModels;

    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ApplicationUsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ApplicationUserPostById GetUserByIdInPost(string id)
        {
            var user = this.usersRepository.All().Where(x => x.Id == id).FirstOrDefault();

            var result = new ApplicationUserPostById()
            {
                UserName = user.UserName,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
            };

            return result;
        }
    }
}
