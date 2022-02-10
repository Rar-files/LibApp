﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Respositories;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRep;
        private readonly GenreRepository _genresRep;

        public BooksController(ApplicationDbContext context)
        {
            _bookRep = new BookRepository(context);
            _genresRep = new GenreRepository(context);
        }

        public IActionResult Index()
        {
            var books = _bookRep.GetBooks().ToList();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRep.GetBookById(id);
                

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookRep.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _genresRep.GetGenres().ToList()
            };

            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var genres = _genresRep.GetGenres().ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _bookRep.Add(book);
            }
            else
            {
                var bookInDb =  _bookRep.GetBookById(book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
            }

            try
            {
                _bookRep.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
        }
    }
}
