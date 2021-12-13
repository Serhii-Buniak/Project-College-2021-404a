using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZooStore.Models;
using ZooStore.Models.Repositories;

namespace ZooStore.Components
{
    public class SearchHistoryViewComponent : ViewComponent
    {
        private readonly ISearchHistoryRepository _searchRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SearchHistoryViewComponent(ISearchHistoryRepository searchHistoryRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _searchRepository = searchHistoryRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(async () =>
            {
                var AllHistory = _searchRepository.SearchHistory.Select(p => p.ToFind).AsEnumerable();
                ClaimsPrincipal principal = (ClaimsPrincipal)User;

                if (_signInManager.IsSignedIn(principal))
                {
                    AppUser user = await _userManager.GetUserAsync(principal);
                    var userHistory = user.SearchHistory.Select(h => h.ToFind).Reverse();
                    AllHistory = userHistory.Union(AllHistory);
                }
                
                return View(AllHistory.Distinct());
            });
        }
    }
}
