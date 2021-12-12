using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZooStore.Models;
using ZooStore.Models.Repositories;

namespace ZooStore.Components
{
    public class SearchHistoryComponent : ViewComponent
    {
        private readonly ISearchHistoryRepository _searchRepository;

        public SearchHistoryComponent(ISearchHistoryRepository searchHistoryRepository, UserManager<AppUser> userManager)
        {
            _searchRepository = searchHistoryRepository;
            _userManager = userManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            User
            return View(_searchRepository.SearchHistory);
        }
    }
}
