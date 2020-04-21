using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The current search terms 
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? IMDBMin { get; set; }

        /// <summary>
        /// The maximum IMDB Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? IMDBMax { get; set; }

        /// <summary>
        /// The minimum RT Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? RottenMin { get; set; }

        /// <summary>
        /// The maximum RT Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? RottenMax { get; set; }

        /// <summary>
        /// Gets the search results for display on the page
        /// </summary>
        public void OnGet(double? IMDBMin, double? IMDBMax, double? RottenMin, double? RottenMax)
        {
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            this.RottenMin = RottenMin;
            this.RottenMax = RottenMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, this.IMDBMin, this.IMDBMax);
            Movies = MovieDatabase.FilterByRottenRating(Movies, this.RottenMin, this.RottenMax);
        }




    }
}
