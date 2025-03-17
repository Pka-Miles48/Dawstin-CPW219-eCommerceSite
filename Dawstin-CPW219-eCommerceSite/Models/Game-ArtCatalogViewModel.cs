namespace Dawstin_CPW219_eCommerceSite.Models
{
    public class Game_ArtCatalogViewModel
    {
        public Game_ArtCatalogViewModel(List<Game_Art> arts, int lastPage, int currPage)
        {
            Game_Arts = arts;
            LastPage = lastPage;
            CurrentPage = currPage;
        }

        public List<Game_Art> Game_Arts { get; private set; }

        /// <summary>
        /// The last page of the catalog. Calculated by
        /// having a total number of products divided by
        /// products per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}
