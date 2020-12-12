using Lab1.DAL.Entities;
using Lab1.Extensions;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.DAL.Data;
using Microsoft.Extensions.Logging;

namespace Lab1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        private List<Dish> _dishes;
        private List<DishGroup> _dishGroups;
        private ILogger _logger;


        int _pageSize;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)

        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
            //SetupData();
        }

        [Route ("Catalog")]
        [Route ("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupMame = group.HasValue
                ? _context.DishGroups.Find(group.Value)?.GroupName
                : "all groups";
            _logger.LogInformation($"info: group={group}, page={pageNo}");
            // var dishesFiltered = _context.Dishes
            //.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,
_pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);

            else
                return View(model);
        }

            //{
            //    return View(_dishes);
            //}
            /// <summary>
            /// Инициализация списков
            /// </summary>
            private void SetupData()
        {
            _dishGroups = new List<DishGroup>
 {
 new DishGroup {DishGroupId=1, GroupName="Стартеры"},
 new DishGroup {DishGroupId=2, GroupName="Салаты"},
 new DishGroup {DishGroupId=3, GroupName="Супы"},
 new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
 new DishGroup {DishGroupId=5, GroupName="Напитки"},
 new DishGroup {DishGroupId=6, GroupName="Десерты"}
 };
            _dishes = new List<Dish>
 {
 new Dish {DishId = 1, DishName="Суп-харчо",
Description="Очень острый",
Calories =470, DishGroupId=3, Image="Харчо.jpg" },
new Dish { DishId = 2, DishName="Борщ",
Description="Много мяса, со сметаной",
Calories =315, DishGroupId=3, Image="Борщ.jpg" },
new Dish { DishId = 3, DishName="Котлета пожарская",
Description="Курица - 80%, Говядина - 20%",
Calories =335, DishGroupId=4, Image="компот.jpg" },
new Dish { DishId = 4, DishName="Макароны по-флотски",
Description="С фаршем говяжьим",
Calories =510, DishGroupId=4, Image="Спагетти.jpg" },
new Dish { DishId = 5, DishName="Компот",
Description="Быстро приготовленный,ягодный 250 мл",
Calories =150, DishGroupId=5, Image="компотик.jpg" }
 };
        }
    }
}

