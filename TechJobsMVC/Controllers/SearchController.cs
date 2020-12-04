using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }
        // catch post request
        public IActionResult Results(string searchType, string searchTerm)
        {
            // if searchterm is empty search using all
            if(searchTerm== "")
            {
              ViewBag.Jobs = JobData.FindAll();
                ViewBag.title = searchTerm;
                
            }
            else
            {
               ViewBag.Jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
                ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;
            }
            // pass in searchterm 
            ViewBag.columns = ListController.ColumnChoices;
            return View("Index");
        }
        // TODO #3: Create an action method to process a search request and render the updated search view. 
    }
}
