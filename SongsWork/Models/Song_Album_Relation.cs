using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsWork.Models
{
    public class Song_Album_Relation
    {
        [Key, Column(Order = 0)]
        public int Song_Album_RelationID { get; set; }

        public int SongID { get; set; }
        public virtual Song Song { get; set; }

        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
    }
}