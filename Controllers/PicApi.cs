using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;
namespace IndieWorld.Controllers
{
    public class PicApi
    {
        public static void Map(WebApplication app)
        {
            //Create a PromotionPic
            app.MapPost("/promotion/pics", (IndieWorldDbContext db, PromotionPic promotionPic) =>
            {
                db.PromotionPics.Add(promotionPic);
                db.SaveChanges();
                return Results.Created($"/promotionpics/{promotionPic.Id}", promotionPic);
            });

            //Delete a PromotionPic
            app.MapDelete("/promotion/pics/{id}", (IndieWorldDbContext db, int id) =>
            {
                var promotionPic = db.PromotionPics.Find(id);
                if (promotionPic == null)
                {
                    return Results.NotFound("PromotionPic not found");
                }
                db.PromotionPics.Remove(promotionPic);
                db.SaveChanges();
                return Results.Ok($"PromotionPic with ID {id} deleted successfully.");
            });

            //Get Promotion and it's PromotionPics
            app.MapGet("/promotions/{id}/pics", (IndieWorldDbContext db, int id) =>
            {
                var promotion = db.Promotions
                .Include(p => p.PromotionPics)
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        Id = p.Id,
                        PromotionName = p.PromotionName,
                        Acronym = p.Acronym,
                        Description = p.Description,
                        Logo = p.Logo,
                        Hq = p.Hq,
                        Established = p.Established,
                        Owner = p.Owner,
                        ShowFrequency = p.ShowFrequency,
                        PromotionPics = p.PromotionPics.Select(pp => new
                        {
                            pp.Id,
                            pp.PromotionId,
                            pp.Image,
                            pp.ShowName,
                            pp.ShowDate,
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (promotion == null)
                {
                    return Results.NotFound("Promotion not found");
                }

                return Results.Ok(promotion);
            });

            //Get PromotionPic by Id
            app.MapGet("/promotion/pics/{id}", (IndieWorldDbContext db, int id) =>
            {
                var promotionPic = db.PromotionPics.Find(id);

                if (promotionPic == null)
                {
                    return Results.NotFound("PromotionPic not found");
                }

                return Results.Ok(promotionPic);
            });

            //Get Performer and their PerformerPics
            app.MapGet("/performers/{id}/pics", (IndieWorldDbContext db, int id) =>
            {
                var performer = db.Performers
                .Include(p => p.PerformerPics)
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        Id = p.Id,
                        RingName = p.RingName,
                        Image = p.Image,
                        Instagram = p.Instagram,
                        X = p.X,
                        Bio = p.Bio,
                        Hometown = p.Hometown,
                        Accolades = p.Accolades,
                        Role = p.Role.Title,
                        Active = p.Active,
                        PerformerPics = p.PerformerPics.Select(pp => new
                        {
                            pp.Id,
                            pp.PerformerId,
                            pp.Image,
                            pp.ShowName,
                            pp.ShowDate,
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (performer == null)
                {
                    return Results.NotFound("Performer not found");
                }

                return Results.Ok(performer);
            });

            //Get PerformerPic by Id
            app.MapGet("/performer/pics/{id}", (IndieWorldDbContext db, int id) =>
            {
                var performerPic = db.PerformerPics.Find(id);

                if (performerPic == null)
                {
                    return Results.NotFound("PerformerPic not found");
                }

                return Results.Ok(performerPic);
            });

            //Create a PerformerPic
            app.MapPost("/performer/pics", (IndieWorldDbContext db, PerformerPic performerPic) =>
            {
                db.PerformerPics.Add(performerPic);
                db.SaveChanges();
                return Results.Created($"/performerpics/{performerPic.Id}", performerPic);
            });

            //Delete a PerformerPic
            app.MapDelete("/performer/pics/{id}", (IndieWorldDbContext db, int id) =>
            {
                var performerPic = db.PerformerPics.Find(id);
                if (performerPic == null)
                {
                    return Results.NotFound("PerformerPic not found");
                }
                db.PerformerPics.Remove(performerPic);
                db.SaveChanges();
                return Results.Ok($"PerformerPic with ID {id} deleted successfully.");
            });
        }
    }
}
