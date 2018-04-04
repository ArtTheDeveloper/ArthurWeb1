using ArthurWebApp.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArthurWebApp.Controllers
{
    public class UsersController : Controller
    {
        private static readonly HttpClient _httpClient;

        static UsersController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://api.github.com/")
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(GetUserRequest model)
        {
            var user = await GetUser(model.Username);
            var repos = await GetRepos(user.Repos_url);

            var userViewModel = new UserViewModel
            {
                Username = user.Login,
                Location = user.Location,
                AvatarUrl = user.Avatar_url,
                Repos = repos.OrderByDescending(r => r.Stargazers_count).Take(5).Select(r =>
                new UserRepoViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    StargazersCount = r.Stargazers_count
                })
            };
            return View("Result", userViewModel);
        }

        private async Task<GetUserResponse> GetUser(string name)
        {
            var response = await _httpClient.GetAsync($"/users/{name}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetUserResponse>();
            }
            return null;
        }

        private async Task<GetReposResponse[]> GetRepos(string reposUrl)
        {
            var response = await _httpClient.GetAsync(reposUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetReposResponse[]>();
            }
            return null;
        }
    }
}
