using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    [Table("Talent")]
    public class Artist
    {
        public string Test { get; set; }
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }
        public int ID { get; set; }
        [Required,StringLength(100),Column("FullName")]
        public string Name { get; set; }
   
    
        public virtual ICollection<ComicBookArtist> ComicBooks { get; set; }


    }
}
