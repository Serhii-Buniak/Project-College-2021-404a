using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooStore.Comparers;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Models.ViewModels;
using ZooStore.Services.SearchServices;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISearchService _searchService;
        private readonly ISearchHistoryRepository _searchHistory;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductHistoryRepository _productHistory;
        private readonly static IDictionary<string, IComparer<Product>> _productComparers = new Dictionary<string, IComparer<Product>>()
        {
            ["Від дорогих до дешевих"] = new ProductComparerByPriceDescending(),
            ["Від дешевих до дорогих"] = new ProductComparerByPriceAscending(),
        };

        public const int pageSize = 8;
        public HomeController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, ISearchService searchService, ISearchHistoryRepository searchHistoryRepository, UserManager<AppUser> userManager, IProductHistoryRepository productHistoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _productRepository = productRepository;
            _searchService = searchService;
            _searchHistory = searchHistoryRepository;
            _userManager = userManager;
            _productHistory = productHistoryRepository;
        }

        public IActionResult Index()
        {
            Dictionary<string, IEnumerable<Subcategory>> dictionary = new();

            foreach (var category in _categoryRepository.Categories)
            {
                dictionary.Add(category.Name, category.Subcategories);
            }
            return View(dictionary);
        }

        [ActionName("Product")]
        public async Task<IActionResult> ShowProduct(long id)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.Id == id);
            if (product is not null)
            {
               await AddToProductHistoryAsync(product);
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Search(long? subcategoryId, string comparer, decimal? minPrice, decimal? maxPrice, string search, int page = 1)
        {
            IEnumerable<Product> products = _productRepository.Products
                .Where(p => subcategoryId == null || p.Subcategory.Id == subcategoryId)
                .Where(p => minPrice == null || p.Price >= minPrice)
                .Where(p => maxPrice == null || p.Price <= maxPrice);

            if (search is not null)
            {
                await AddToSearchHistoryAsync(search);
                products = _searchService.GetSerchedProducts(products, search);
            }
            if (comparer is not null)
                products = products.OrderBy(p => p, _productComparers[comparer]);
            decimal? min = default;
            decimal? max = default;
            if (products.Any())
            {
                min = products?.Min(p => p.Price);
                max = products?.Max(p => p.Price);
            }

            return View(new ProductListViewModel()
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = products?.Count() ?? 0,
                },
                SubcategoryId = subcategoryId,
                SubcategoriesList = new SelectList(_subcategoryRepository.Subcategories, "Id", "Name", subcategoryId),
                ComparersList = new SelectList(_productComparers.Keys, comparer),
                SearchText = search,
                MinPrice = min,
                MaxPrice = max,
                Comparer = comparer
            });
        }
        public IActionResult WhyWeAre()
        {
            return View();
        }

        private async Task AddToSearchHistoryAsync(string toFind)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            await _searchHistory.AddAsync(new SearchHistory { ToFind = toFind, User = user });
        }

        private async Task AddToProductHistoryAsync(Product product)
        {                    
            AppUser user = await _userManager.GetUserAsync(User);
            await _productHistory.AddAsync(new ProductHistory { Product = product, User = user });
        }

    }

}


