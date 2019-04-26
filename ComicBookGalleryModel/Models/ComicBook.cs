using System;
using System.Collections.Generic;
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
        public string SeriesTitle { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? Averagerating { get; set; } //questionMark to make it nullable
    }
}
