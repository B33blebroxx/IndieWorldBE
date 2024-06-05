using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace IndieWorld.Controllers
{
    public class ShowApi
    {
        public static void Map(WebApplication app)
        {
            //Create a show
            app.MapPost("/shows", (IndieWorldDbContext db, Show show) =>
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return Results.Created($"/shows/{show.Id}", show);
            });

            //Edit a show
            app.MapPut("/shows/{id}", (IndieWorldDbContext db, int id, Show updatedShow) =>
            {
                var show = db.Shows.Find(id);
                if (show == null)
                {
                    return Results.NotFound("Show not found");
                }
                show.ShowName = updatedShow.ShowName;
                show.ShowImage = updatedShow.ShowImage;
                show.Location = updatedShow.Location;
                show.ShowDate = updatedShow.ShowDate;
                show.ShowTime = updatedShow.ShowTime;
                show.Price = updatedShow.Price;

                db.SaveChanges();
                return Results.Ok(show);
            });

            //Delete a Show
            app.MapDelete("shows/{id}", (IndieWorldDbContext db, int id) =>
            {
                var show = db.Shows.Find(id);
                if (show == null)
                {
                    return Results.NotFound("");
                }
                db.Shows.Remove(show);
                db.SaveChanges();
                return Results.Ok($"Show with ID {id} deleted successfully.");
            });

            //Get a Show and its Performers
            app.MapGet("/shows/{showId}/performers", (IndieWorldDbContext db, int showId) =>
            {
                var show = db.Shows
                    .Include(s => s.Performers)
                    .Where(s => s.Id == showId)
                    .Select(s => new
                    {
                        Id = s.Id,
                        PromotionId = s.PromotionId,
                        ShowName = s.ShowName,
                        ShowImage = s.ShowImage,
                        Location = s.Location,
                        ShowDate = s.ShowDate,
                        ShowTime = s.ShowTime,
                        Price = s.Price,
                        ShowComplete = s.ShowComplete,
                        Performers = s.Performers.Select(p => new
                        {
                            Id = p.Id,
                            RingName = p.RingName,
                            Image = p.Image,
                            Bio = p.Bio,
                            Hometown = p.Hometown,
                            Accolades = p.Accolades,
                            RoleId = p.RoleId,
                            Role = p.Role.Title,
                            Active = p.Active
                        }).OrderBy(p => p.RingName).ToList()
                    })
                    .FirstOrDefault();

                if (show == null)
                {
                    return Results.NotFound("Show not found");
                }

                return Results.Ok(show);
            });

            //Add Performer to Show
            app.MapPost("/shows/{showId}/performers/{performerId}", (IndieWorldDbContext db, int showId, int performerId) =>
            {
                var show = db.Shows.Include(s => s.Performers).FirstOrDefault(s => s.Id == showId);
                var performer = db.Performers.FirstOrDefault(p => p.Id == performerId);

                if (show == null)
                {
                    return Results.NotFound("Show not found");
                }

                if (performer == null)
                {
                    return Results.NotFound("Performer not found");
                }

                if (show.Performers.Contains(performer))
                {
                    return Results.BadRequest("Performer is already added to the show");
                }

                    show.Performers.Add(performer);
                    db.SaveChanges();
                

                return Results.Ok(new { Message = "Performer added to show successfully", ShowId = showId, PerformerId = performerId });
            });

            //Remove a Performer from a Show
            app.MapDelete("/shows/{showId}/performers/{performerId}", (IndieWorldDbContext db, int showId, int performerId) =>
            {
                var show = db.Shows.Include(s => s.Performers).FirstOrDefault(s => s.Id == showId);
                var performer = db.Performers.FirstOrDefault(p => p.Id == performerId);

                if (show == null)
                {
                    return Results.NotFound("Show not found");
                }

                if (performer == null)
                {
                    return Results.NotFound("Performer not found");
                }

                if (!show.Performers.Contains(performer))
                {
                    return Results.BadRequest("Performer is not part of the show");
                }

                show.Performers.Remove(performer);
                db.SaveChanges();

                return Results.Ok(new { Message = "Performer removed from show successfully", ShowId = showId, PerformerId = performerId });
            });

            //Get all Shows
            app.MapGet("/shows", (IndieWorldDbContext db) =>
            {
                var shows = db.Shows
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
                    .OrderBy(s => s.ShowDate)
                    .ToList();

                return Results.Ok(shows);
            });




        }
    }
}
