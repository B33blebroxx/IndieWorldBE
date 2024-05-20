using IndieWorld.Models;

namespace IndieWorld.API
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

        }
    }
}
