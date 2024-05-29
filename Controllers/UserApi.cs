using Microsoft.EntityFrameworkCore;
using IndieWorld.Models;

namespace IndieWorld.Controllers
{
    public class UserApi
    {
        public static void Map(WebApplication app)
        {
            //Check User
            app.MapGet("/checkUser/{uid}", (IndieWorldDbContext db, string uid) =>
            {
                var user = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(user);
            });

            //Register User
            app.MapPost("/users/register", (IndieWorldDbContext db, User newUser) =>
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to register user");
                }
            });

            //Update User
            app.MapPut("/users/update/{id}", (IndieWorldDbContext db, int id, User updatedUser) =>
            {
                var user = db.Users.Find(id);

                if (user == null)
                {
                    return Results.NotFound("");
                }
                if (updatedUser.PromotionId != null)
                {
                    user.PromotionId = updatedUser.PromotionId;
                }

                if (updatedUser.PerformerId != null)
                {
                    user.PerformerId = updatedUser.PerformerId;
                }

                db.SaveChanges();

                return Results.Ok(user);
            });

        }
    }
}
