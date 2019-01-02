using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongsWork.Models;
using SongWork.Tools;

namespace SongsWork.Controllers
{
    public class SongController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Song
        //public ActionResult Index()
        //{
        //    List<Song> SongList = db.Songs.ToList(); 
        //    return View(SongList);
        //}

        public ActionResult SongList()
        {
            List<Song> SongList = db.Songs.ToList();
            return View(SongList);
        }

        public ActionResult SongDetails(int Id)
        {
            Song Song_Object = db.Songs.Find(Id);

            if (null != Song_Object)
            {
                return (View(Song_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        public ActionResult DeleteSong(int Id)
        {
            Song Song_Object = db.Songs.Find(Id);

            if (null != Song_Object)
            {
                db.Songs.Remove(Song_Object);
                db.SaveChanges();
            }
            return (RedirectToAction("Songlist", "Song"));
        }

        public ActionResult CreateSong()
        {
            List<Genre> GenreList = db.Genres.ToList();

            return (View(GenreList));
        }

        [HttpPost]
        public ActionResult CreateSong(Song Song_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                Song_Object.SongTitle =
                    StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Song_Object.SongTitle, ' ');

                db.Songs.Add(Song_Object);
                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("SongList", "Song"));
                }
                else
                {
                    return (RedirectToAction("Index", "Home"));
                }
            }
            else
            {
                return (View());
            }
        }

        public ActionResult EditSong(int Id)
        {
            Song Song_Object = db.Songs.Find(Id);
            ViewBag.GenreList = db.Genres.ToList();

            return (View(Song_Object));
        }

        [HttpPost]
        public ActionResult EditSong(Song Song_Object)
        {
            int NumberOfRecordsSaved = 0;

            Song Song_ObjectSave = db.Songs.Find(Song_Object.SongID);
            Song_ObjectSave.GenreID = Song_Object.GenreID;
            Song_ObjectSave.SongTitle = StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Song_Object.SongTitle, ' ');
           
            NumberOfRecordsSaved = db.SaveChanges();

            if (NumberOfRecordsSaved > 0)
            {
                return (RedirectToAction("SongList", "Song"));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }
    }
}