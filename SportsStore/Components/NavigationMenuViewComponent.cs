using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;

namespace SportsStore.Components
{
	public class NavigationMenuViewComponent : ViewComponent
	{
		private  IStoreRepository repository;

		public NavigationMenuViewComponent(IStoreRepository ctx)
		{
			repository = ctx;
		}

		public IViewComponentResult Invoke() {
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(repository.Products
			 .Select(x => x.Category)
			 .Distinct()
			 .OrderBy(x => x));
		}
	}
}