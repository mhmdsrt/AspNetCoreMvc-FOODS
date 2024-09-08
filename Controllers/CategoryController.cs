using AspNetCoreFood.Models;
using AspNetCoreFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;



namespace AspNetCoreFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult GetAllCategory(string searchWord,int page=1) 
        {
            if (!string.IsNullOrEmpty(searchWord)) // searchWord değeri boş ya da null(geçersiz,boş) değilse
            {
                return View(categoryRepository.GetAll().Where(x=>x.CategoryName.Contains(searchWord)).ToPagedList(page,10));
            }
            return View(categoryRepository.GetAll().ToPagedList(page, 10));

        }

        [HttpGet]
        public IActionResult InsertCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertCategory(Category entity)
        {
            entity.Status = true;
            categoryRepository.Insert(entity);
            return RedirectToAction("GetAllCategory");
        }

        public IActionResult DeleteCategory(int id)
        {
            var categoryToDelete = categoryRepository.GetById(id);
            categoryToDelete.Status = false;
            categoryRepository.Update(categoryToDelete);
            return RedirectToAction("GetAllCategory");
        }

        [HttpGet]
        public IActionResult GetCategoryToUpdate(int id)
        {
            var categoryToUpdate = categoryRepository.GetById(id);
            return View(categoryToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category entity)
        {
           
            categoryRepository.Update(entity);
            return RedirectToAction("GetAllCategory");
        }
    }
}
