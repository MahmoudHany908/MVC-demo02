using Microsoft.AspNetCore.Routing.Constraints;

namespace Demo2
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/Index", () => "Hello Index!");
            app.MapControllerRoute(
                name: "DefaultWithoutId",
                pattern: "{controller=Item}/{action=Index}");
            app.MapControllerRoute(
                name: "Default",
                pattern:"{controller=Item}/{action=Index}/{Id:regex(^\\d{{2}}$)}"//I wrote here id with capital I, yet VS can still recongize it and bind it with it's action
                                                      //id is optional
                                                      //So I can access Index too without making a new route
                                                      //Also if I don't send id it will add the default value(Zero)
                                                      //A good practice is to make this variable nullable also for the action as you mentioned here it's not mandatory so it's logical :)
                                                      //And instead now, it'll set the id to null if I don't send an id(So I can Identify that not item zero, but no id was sent at all in the 1st place)
                                                      //instead of using Defaults or contraints I added them directly also
                
                //defaults: new { action = "Index", controller = "Item" },
               
                //constraints:new {id=new IntRouteConstraint()} //if value sent not int handle it(Views page not found cuz I am not supposed to reach something if I send "Mah" as id)
                //            new {id=@"\d{2}"}
                );                                   
                                                     
            //Variable Segment(Write your name in the URL and it'll display it)

            //app.MapGet("/{name}", async context =>
            //{
            //    var Name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello {Name}");

            //}
            //);

            //Mixed Segment

            //Must write X then then put whatever you want in the name
            app.MapGet("/X{name}", async context =>
            {
                //Made it directly without creating a variable
                await context.Response.WriteAsync($"Hello {context.Request.RouteValues["name"]}");

            }
            );

            app.Run();
        }
    }
}
