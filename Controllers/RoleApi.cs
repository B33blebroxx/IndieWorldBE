namespace IndieWorld.Controllers
{
    public class RoleApi
    {
        public static void Map(WebApplication app)
        {
            //Get all Roles
            app.MapGet("/roles", (IndieWorldDbContext db) =>
            {
                var roles = db.Roles.ToList();
                if (roles == null)
                {
                    return Results.NoContent();
                }

                return Results.Ok(roles);
            });
        }
    }
}
