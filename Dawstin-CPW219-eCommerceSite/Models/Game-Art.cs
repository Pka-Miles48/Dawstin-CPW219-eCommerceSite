using System.ComponentModel.DataAnnotations;

namespace Dawstin_CPW219_eCommerceSite.Models
{
    /// <summary>
    /// Represents a single game and piece of art for available for purchase
    /// </summary>
    public class Game_Art
    {
        /// <summary>
        /// The unique identifier for each game and/or art product
        /// </summary>
        [Key]
        public int Game_ArtId { get; set; }

        /// <summary>
        /// The official title of the Video Game or Painting
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sales price of the game or painting
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }

        // Todo: Add rating
    }
}
