using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramBot.Core.Configs;
using InstagramBot.Core.Interfaces;
using InstagramBot.Core.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace InstagramBot.Infrustracture.Services
{
    public class InstagramPrivateApiService : IInstagramService
    {
        private readonly InstagramUserCredential instagramUserCredential1;
private IInstaApi api;

        private const string _stateFileName = "state.txt";

        public InstagramPrivateApiService(IOptionsSnapshot<InstagramUserCredential> instagramUserCredential)
        {
            this.instagramUserCredential1 = instagramUserCredential.Value; 
        }

        public Task<string> CreatePost(string caption, string[] images)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InstagramPostViewModel>> GetPosts()
        {
            throw new NotImplementedException();
        }

        private async Task Login()
        {
            var delay = RequestDelay.FromSeconds(1, 3);
            api = InstaApiBuilder.CreateBuilder()
                .SetRequestDelay(delay)
                .SetUser(new UserSessionData { UserName = instagramUserCredential1.Username, Password = instagramUserCredential1.Password })
                .Build();

            var lastState = await GetLastState();
            if (!string.IsNullOrEmpty(lastState))
            {
                await api.LoadStateDataFromStringAsync(lastState);
            }

            if (!api.IsUserAuthenticated)
            {
                var loginResult = await api.LoginAsync();
                if (loginResult.Succeeded)
                {
                    await SaveState();
                }
            }
        }

        private async Task SaveState()
        {
            var state = await api.GetStateDataAsStringAsync();
            var statePath = GetOrCreateStateDirectory();

            await File.WriteAllTextAsync(Path.Combine(statePath, _stateFileName), state);
        }

        private string GetOrCreateStateDirectory()
        {
            var statePath = Path.Combine(Directory.GetCurrentDirectory(), instagramUserCredential1.Username);
            if (!Directory.Exists(statePath))
            {
                Directory.CreateDirectory(statePath);
            }

            return statePath;
        }

        private Task<string> GetLastState()
        {
            return File.ReadAllTextAsync(Path.Combine(GetOrCreateStateDirectory(), _stateFileName));
        }
    }
}
