using RentalMovies.Data;
using RentalMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace RentalMovies.Areas.Admin.Controllers
{
    public class MoviesController : Controller
    {
        private MyContext _context;
        public MoviesController()
        {
            _context = new MyContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Movies
        public ActionResult Index()
        {
            var movies = _context.tbl_movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movies = _context.tbl_movies.Include(m => m.Genre).Where(m => m.movieId == Id).FirstOrDefault();

            if (movies == null)
                return HttpNotFound();
            else
            {
                return View(movies);
            }
        }


        public ActionResult AddNewMovie()
        {
            var Genres = _context.tbl_genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre = Genres
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewMovie(MovieFormViewModel model, HttpPostedFileBase ImageURL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Movies movies1 = new Movies();

                    movies1.Name = model.Movies.Name;
                    movies1.ReleaseDate = model.Movies.ReleaseDate;
                    movies1.NumberInStock = model.Movies.NumberInStock;
                    movies1.GenreId = model.Movies.GenreId;

                    movies1.DateAdded = DateTime.Now;

                    if (ImageURL != null)
                    {
                        string name = Path.GetFileName(ImageURL.FileName);
                        string path = Server.MapPath("~/Images/MovieCovers/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        ImageURL.SaveAs(path + name);
                        movies1.ImageURL = name;
                    }


                    //string path = Path.Combine(Server.MapPath("~/Images/MovieCovers/"), Path.GetFileName(ImageURL.FileName));
                    //ImageURL.SaveAs(path);

                    //movies1.ImageURL = path;

                    _context.tbl_movies.Add(movies1);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Movies");
                }
                var Genres = _context.tbl_genres.ToList();
                var viewModel = new MovieFormViewModel
                {
                    Genre = Genres
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {

                ViewBag.erro = "Exception : " + ex.Message;
                return View();
            }
        }

        public ActionResult EditMov(int Id)
        {
            var movies = _context.tbl_movies.SingleOrDefault(m => m.movieId == Id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movies = movies,
                Genre = _context.tbl_genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditMov(MovieFormViewModel model, HttpPostedFileBase ImageURL)
        {
            if (model.Movies.movieId == 0)
            {
                return HttpNotFound();
            }


            var moviesInDB = _context.tbl_movies.Single(m => m.movieId == model.Movies.movieId);
            moviesInDB.Name = model.Movies.Name;
            moviesInDB.ReleaseDate = model.Movies.ReleaseDate;
            moviesInDB.NumberInStock = model.Movies.NumberInStock;
            moviesInDB.GenreId = model.Movies.GenreId;

            if (ImageURL != null)
            {
                string name = Path.GetFileName(ImageURL.FileName);
                string path = Server.MapPath("~/Images/MovieCovers/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ImageURL.SaveAs(path + name);
                moviesInDB.ImageURL = name;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(int Id)
        {
            var data = _context.tbl_movies.Where(m => m.movieId == Id).FirstOrDefault();
            _context.tbl_movies.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

    }
}