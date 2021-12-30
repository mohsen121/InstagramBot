using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramBot.Core.ViewModels;

namespace InstagramBot.Core.Interfaces
{
    public interface IInstagramService
    {
        public Task Login();
        public Task<string> CreatePost(string caption, string[] images);
        public Task<IEnumerable<InstagramPostViewModel>> GetPosts();
    }
}
