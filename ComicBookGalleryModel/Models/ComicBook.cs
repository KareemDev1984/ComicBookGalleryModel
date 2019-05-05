using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
       // EF only adds table columns for entity properties that have a setter—public, protected, or private.

        // ID wordt automatisch PrimaryKey in SQL en omdat het een numeriek veld is wordt dit automatisch ook Identity
        public int Id { get; set; }
        public int SeriesId { get; set; }

        //[ForeignKey("SeriesRefId")]  //als we van de conventie afwijken (moesten we de foreignkey SeriesId hebben genoemd zou EF deze automtisch detecteren, maar nu moeten we het zelf aanduiden */als foreignKey)
        //public Series Series { get; set; }

        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; } //questionMark to make it nullable

        public virtual ICollection<ComicBookArtist> Artists { get; set; }

        public virtual Series Series { get; set; }


        public string  DisplayText
        {
            get { return $"{Series?.Title}  #{IssueNumber}"; }
       
        }

        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }

    }
}
