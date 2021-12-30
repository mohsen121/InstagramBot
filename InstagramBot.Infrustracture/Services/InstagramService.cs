using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramBot.Core.Interfaces;
using InstagramBot.Core.ViewModels;

namespace InstagramBot.Infrustracture.Services
{
    public class InstagramService : IInstagramService
    {
        public Task<string> CreatePost(string caption, string[] images)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InstagramPostViewModel>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task Login()
        {
            throw new NotImplementedException();
        }
    }
}
