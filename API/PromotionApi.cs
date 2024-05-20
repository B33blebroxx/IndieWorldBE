using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace IndieWorld.API
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
                promotion.LogoUrl = updatedPromotion.LogoUrl;
                promotion.Hq = updatedPromotion.Hq;
                promotion.Established = updatedPromotion.Established;
                promotion.Owner = updatedPromotion.Owner;
                promotion.ShowFrequency = updatedPromotion.ShowFrequency;

                db.SaveChanges();
                return Results.Ok(promotion);
            });

            // Get Promotion and its Shows
            app.MapGet("/promotions/{promotionId}/shows", (IndieWorldDbContext db, int promotionId) =>
            {
                var promotion = db.Promotions.Include(p => p.Shows).FirstOrDefault(p => p.Id == promotionId);
                if (promotion == null)
                {
                    return Results.NotFound("Promotion not found");
                }

                var sortedShows = promotion.Shows.OrderBy(s => s.ShowName).ToList();
                return Results.Ok(new
                {
                    PromotionId = promotion.Id,
                    PromotionName = promotion.PromotionName,
                    Acronym = promotion.Acronym,
                    LogoUrl = promotion.LogoUrl,
                    Hq = promotion.Hq,
                    Established = promotion.Established,
                    Owner = promotion.Owner,
                    ShowFrequency = promotion.ShowFrequency,
                    Shows = sortedShows.Select(s => new
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


        }
    }
};
