using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongsWork.Models;

namespace SongsWork.Controllers
{
    public class SongController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Song
        public ActionResult Index()
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
    }
}