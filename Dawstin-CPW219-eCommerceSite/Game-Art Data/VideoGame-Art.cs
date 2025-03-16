using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace Dawstin_CPW219_eCommerceSite.Game_Art_Data
{
    public class VideoGame_Art : DbContext
    {
        public VideoGame_Art(DbContextOptions<VideoGame_Art> options) 
            : base(options)
        {

        }

        public DbSet<Game_Art> Game_Arts { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
