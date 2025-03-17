using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Demo2.Controllers
{
    public class ItemController : Controller
    {
        [NonAction]
        public void DeleteItem()
        {

        }


        public string Index()
        {
            return "Hello from index";
        }



        //baseURL/item/GetItem/10

        //I could also remove id from the pattern there and then the URL will be like this to access item with specific id and name

        //baseURL/item/GetItem/?Id=10&?itemName=Chair

        #region Example01
        //[HttpGet]
        //public ContentResult GetItem(int? id, string itemName)
        //{

        //    //ContentResult res = new ContentResult();
        //    //res.Content = $"Item with name={itemName} </br> and id = {id}";
        //    //res.ContentType = "text/html";
        //    //res.StatusCode = 700;//We don't use it usuallly, cuz why :)
        //    //return res;


        //    //In case function uses string not ContentResult
        //    //return $"Item with name={itemName} and id = {id}";


        //    //Easiest approach is using nhelper method instead of creating an object

        //    return Content($"Item with name={itemName} </br> and id = {id}", "text/html");


        //}

        #endregion


        [HttpGet]
        public IActionResult GetItem(int? id, string itemName)
        {
            // Id = 0 -> Bad Request
            // Id < 10 -> Not Found
            // Id >= 10 -> Return Movie

            if (id == 0)
                return BadRequest();
            else if (id < 10)
                return NotFound();
            else
                return Content($"Movie With Name = {itemName} And Id = {id}", contentType: "text/html");


        }


        public IActionResult TestRedirectAction()
        {
            //return Redirect("localhost//");

            //when using a URL that changes frequently it's better to use this

            //return RedirectToAction("GetItem", "Item", new {id=10,itemName="Test"});

            //Safer approach to not use strings
            //return RedirectToAction(nameof(GetItem), "Item", new { id = 10, itemName = "Test" });

            //Note: I can't use nameof with the COntroller as it'll return the fullname "ItemController"
            //which will throw an exception and I'll have to use splitting
            //So for controller, we could use String normally but make sure it's 100% correct

            //I could also use redirect to route
            return RedirectToRoute("Default", new { Controller = "Item", Action = "GetItem", id = 10 });

        }



    }
}
