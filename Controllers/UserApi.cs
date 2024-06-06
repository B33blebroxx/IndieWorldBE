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

            //Update User Promotion
            app.MapPut("/users/{id}/promotion", (IndieWorldDbContext db, int id, User updatedUser) =>
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return Results.NotFound("User not found");
                }
                user.PromotionId = updatedUser.PromotionId;

                db.SaveChanges();
                return Results.Ok(user);
            });

            //Update User Performer
            app.MapPut("/users/{id}/performer", (IndieWorldDbContext db, int id, User updatedUser) =>
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return Results.NotFound("User not found");
                }
                user.PerformerId = updatedUser.PerformerId;

                db.SaveChanges();
                return Results.Ok(user);
            });
            
            //Get User
            app.MapGet("/users/{id}", (IndieWorldDbContext db, int id) =>
            {
                var user = db.Users.Find(id);

                if (user == null)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(user);
            });

        }
    }
}
