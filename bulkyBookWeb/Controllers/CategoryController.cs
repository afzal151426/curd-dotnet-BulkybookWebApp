﻿using bulkyBookWeb.Data;
using bulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder Can not exactly Match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";

               return RedirectToAction("Index");
            }
                return View(obj);
        }
        public IActionResult Edit(int ?id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder Can not exactly Match the Name");
            }
            if(ModelState.IsValid)
            { 
              _db.Categories.Update(obj);
              _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
                return View(obj);
        }
        //GET--DELETE
        public IActionResult Delete(int ?id)
        {
            if(id==null|| id==0)
            {
                return NotFound();
            }
            var CategoryfromDb=_db.Categories.Find(id);
            if(CategoryfromDb == null)
            {
                return NotFound();
            }

            return View(CategoryfromDb);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
		//POST--DELETE
		public IActionResult DeletePost(int ?id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}
