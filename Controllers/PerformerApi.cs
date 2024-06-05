using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace IndieWorld.Controllers
{
    public class PerformerApi
    {
        public static void Map(WebApplication app)
        {
            //Create a Performer
            app.MapPost("/performers", (IndieWorldDbContext db, Performer performer) =>
            {
                db.Performers.Add(performer);
                db.SaveChanges();
                return Results.Created($"/performers/{performer.Id}", performer);
            });

            //Get All Performers
            app.MapGet("/performers", (IndieWorldDbContext db) =>
            {
                var performers = db.Performers.Include(p => p.Role).OrderBy(p => p.RingName).ToList();
                if (performers == null || performers.Count == 0)
                {
                    return Results.NotFound("");
                }
                return Results.Ok(performers);
            });

            //Update a Performer
            app.MapPut("/performers/{id}", (IndieWorldDbContext db, int id, Performer updatedPerformer) =>
            {
                var performer = db.Performers.Find(id);
                if (performer == null)
                {
                    return Results.NotFound("Performer not found");
                }
                performer.RingName = updatedPerformer.RingName;
                performer.Hometown = updatedPerformer.Hometown;
                performer.Image = updatedPerformer.Image;
                performer.Accolades = updatedPerformer.Accolades;
                performer.Bio = updatedPerformer.Bio;
                performer.Role = updatedPerformer.Role;
                performer.Active = updatedPerformer.Active;

                db.SaveChanges();
                return Results.Ok(performer);
            });

            //Delete a Performer
            app.MapDelete("/performers/{id}", (IndieWorldDbContext db, int id) =>
            {
                var performer = db.Performers.Find(id);
                if (performer == null)
                {
                    return Results.NotFound("");
                }

                db.Performers.Remove(performer);
                db.SaveChanges();
                return Results.Ok($"Performer with ID {id} deleted successfully.");
            });

            //Get a Performer and Their Shows
            app.MapGet("/performers/{performerId}/shows", (IndieWorldDbContext db, int performerId) =>
            {
                var performer = db.Performers
                    .Include(p => p.Shows)
                    .Where(p => p.Id == performerId)
                    .Select(p => new
                    {
                        Id = p.Id,
                        RingName = p.RingName,
                        Image = p.Image,
                        Bio = p.Bio,
                        Hometown = p.Hometown,
                        Accolades = p.Accolades,
                        RoleId = p.RoleId,
                        Active = p.Active,
                        Shows = p.Shows
                            .OrderBy(s => s.ShowDate)
                            .Select(s => new
                            {
                                Id = s.Id,
                                ShowName = s.ShowName,
                                ShowImage = s.ShowImage,
                                Location = s.Location,
                                ShowDate = s.ShowDate,
                                ShowTime = s.ShowTime,
                                Price = s.Price,
                                ShowComplete = s.ShowComplete
                            })
                            .ToList()
                    })
                    .FirstOrDefault();

                if (performer == null)
                {
                    return Results.NotFound("Performer not found");
                }

                return Results.Ok(performer);
            });
        }
    }
}
