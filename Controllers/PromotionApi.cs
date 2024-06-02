using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace IndieWorld.Controllers
{
    public class PromotionApi
    {
        public static void Map(WebApplication app)
        {
            //Get All Promotions
            app.MapGet("/promotions", (IndieWorldDbContext db) =>
            {
                var promotions = db.Promotions.ToList();

                if (promotions == null || promotions.Count == 0)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(promotions);
            });

            //Create Promotion
            app.MapPost("/promotions", (IndieWorldDbContext db, Promotion promotion) =>
            {
                db.Promotions.Add(promotion);
                db.SaveChanges();
                return Results.Created($"/promotions/{promotion.Id}", promotion);
            });

            //Edit Promotion
            app.MapPut("/promotions/{id}", (IndieWorldDbContext db, int id, Promotion updatedPromotion) =>
            {
                var promotion = db.Promotions.Find(id);
                if (promotion == null)
                {
                    return Results.NotFound("Promotion not found");
                }
                promotion.PromotionName = updatedPromotion.PromotionName;
                promotion.Acronym = updatedPromotion.Acronym;
                promotion.Description = updatedPromotion.Description;
                promotion.Logo = updatedPromotion.Logo;
                promotion.Hq = updatedPromotion.Hq;
                promotion.Established = updatedPromotion.Established;
                promotion.Owner = updatedPromotion.Owner;
                promotion.ShowFrequency = updatedPromotion.ShowFrequency;

                db.SaveChanges();
                return Results.Ok(promotion);
            });

            // Get Promotion and its Shows
            app.MapGet("/promotions/profile/{id}", (IndieWorldDbContext db, int id) =>
            {
                var promotion = db.Promotions.Include(p => p.Shows).FirstOrDefault(p => p.Id == id);
                if (promotion == null)
                {
                    return Results.NotFound("Promotion not found");
                }

                var sortedShows = promotion.Shows.OrderBy(s => s.ShowName).ToList();
                return Results.Ok(new
                {
                    id = promotion.Id,
                    promotionName = promotion.PromotionName,
                    acronym = promotion.Acronym,
                    description = promotion.Description,
                    logo = promotion.Logo,
                    hq = promotion.Hq,
                    established = promotion.Established,
                    owner = promotion.Owner,
                    showFrequency = promotion.ShowFrequency,
                    shows = sortedShows.Select(s => new
                    {
                        s.Id,
                        s.PromotionId,
                        s.ShowName,
                        s.ShowImage,
                        s.Location,
                        s.ShowDate,
                        s.ShowTime,
                        s.Price,
                        s.ShowComplete
                    })
                });
            });

            //Get Promotion
            app.MapGet("/promotions/{id}", (IndieWorldDbContext db, int id) =>
            {
                var promotion = db.Promotions.Find(id);

                if (promotion == null)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(promotion);
            });
        }
    }
};
