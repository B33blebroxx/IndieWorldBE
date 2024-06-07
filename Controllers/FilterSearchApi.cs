using Microsoft.EntityFrameworkCore;

namespace IndieWorld.Controllers
{
    public class FilterSearchApi
    {
        public static void Map(WebApplication app)
        {
            //Search Shows by ShowName
            app.MapGet("/search/shows", (IndieWorldDbContext db, string query) =>
            {
                var shows = db.Shows
                    .Where(s => EF.Functions.ILike(s.ShowName, $"%{query}%"))
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
                    .ToList();

                if (!shows.Any())
                {
                    return Results.NotFound("No shows found with the specified query.");
                }

                return Results.Ok(shows);
            });

            //Search Performers by RingName
            app.MapGet("/search/performers", (IndieWorldDbContext db, string query) =>
            {
                var performers = db.Performers
                    .Where(p => EF.Functions.ILike(p.RingName, $"%{query}%"))
                    .Select(p => new
                    {
                        PerformerId = p.Id,
                        RingName = p.RingName,
                        Image = p.ImageUrl,
                        Bio = p.Bio,
                        Hometown = p.Hometown,
                        Accolades = p.Accolades,
                        RoleId = p.RoleId,
                        Active = p.Active
                    })
                    .ToList();

                if (!performers.Any())
                {
                    return Results.NotFound("No performers found with the specified query.");
                }

                return Results.Ok(performers);
            });

            //Search Promotions by name
            app.MapGet("/search/promotions", (IndieWorldDbContext db, string query) =>
            {
                var promotions = db.Promotions
                    .Where(p => EF.Functions.ILike(p.PromotionName, $"%{query}%") || EF.Functions.Like(p.Acronym, $"%{query}%"))
                    .Select(p => new
                    {
                        PromotionId = p.Id,
                        PromotionName = p.PromotionName,
                        Description = p.Description,
                        Acronym = p.Acronym,
                        Logo = p.Logo,
                        Hq = p.Hq,
                        Established = p.Established,
                        Owner = p.Owner,
                        ShowFrequency = p.ShowFrequency
                    })
                    .ToList();

                if (!promotions.Any())
                {
                    return Results.NotFound("No promotions found with the specified query.");
                }

                return Results.Ok(promotions);
            });

            //Sort Shows by Soonest to Latest
            app.MapGet("/promotions/{promotionId}/shows/sortedbydatetime", (IndieWorldDbContext db, int promotionId) =>
            {
                var promotion = db.Promotions.Include(p => p.Shows).FirstOrDefault(p => p.Id == promotionId);
                if (promotion == null)
                {
                    return Results.NotFound("");
                }

                var sortedShows = promotion.Shows.OrderBy(s => s.ShowDate).ToList();
                return Results.Ok(new { Promotion = promotion, Shows = sortedShows });
            });

        }
    }
}
