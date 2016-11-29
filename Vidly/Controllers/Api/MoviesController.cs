﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery =
                _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if(!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return NotFound();
            } else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            } else
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);

                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDto.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
            }
        }


        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movieInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map(movieDto, movieInDb);

                    _context.SaveChanges();
                }
            }
        }

        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            } else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
        }
    }
}
