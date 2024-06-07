using IndieWorld.Models;
using Microsoft.EntityFrameworkCore;
namespace IndieWorld.Controllers
{
    public class PromotionPicApi
    {
        public static void Map(WebApplication app)
        {
            //Create a PromotionPic
            app.MapPost("/promotionpics", (IndieWorldDbContext db, PromotionPic promotionPic) =>
            {
                db.PromotionPics.Add(promotionPic);
                db.SaveChanges();
                return Results.Created($"/promotionpics/{promotionPic.Id}", promotionPic);
            });

            //Get Promotion and it's PromotionPics
            app.MapGet("/promotions/{id}/promotionpics", (IndieWorldDbContext db, int id) =>
            {
                var promotion = db.Promotions
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
                            pp.PromotionImage
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
            app.MapGet("/promotionpics/{id}", (IndieWorldDbContext db, int id) =>
            {
                var promotionPic = db.PromotionPics.Find(id);

                if (promotionPic == null)
                {
                    return Results.NotFound("PromotionPic not found");
                }

                return Results.Ok(promotionPic);
            });


        }
    }
}
