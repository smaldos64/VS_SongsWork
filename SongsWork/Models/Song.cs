using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsWork.Models
{
    public class Song
    {
        public int SongID { get; set; }

        [Required]
        public string SongTitle { get; set; }

        //public string SongPath { get; set; }

        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        //public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Song_Album_Relation> Song_Album_Relations { get; set; }
    }
}