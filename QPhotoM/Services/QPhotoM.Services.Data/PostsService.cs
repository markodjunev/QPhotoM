namespace QPhotoM.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using QPhotoM.Data.Common.Repositories;
    using QPhotoM.Data.Models;
    using QPhotoM.Services.Data.Interfaces;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task CreateAsync(string description, string photoUrl, string creatorId)
        {
            var post = new Post
            {
                Description = description,
                PhotoUrl = photoUrl,
                CreatorId = creatorId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public Post GetById(string id)
        {
            var post = this.postsRepository.All().Where(x => x.Id == id).FirstOrDefault();

            return post;
        }
    }
}
