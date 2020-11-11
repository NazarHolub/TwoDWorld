using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoDWorldBackEnd.DAL;
using TwoDWorldBackEnd.DAL.Entities;
using TwoDWorldBackEnd.DTO.EntityDto;
using TwoDWorldBackEnd.DTO.ResultDto;

namespace TwoDWorldBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly EFContext _context;
        public GenreController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ResultDto GetGenres()
        {
            try
            {
                List<GenreDto> genres = new List<GenreDto>();
                foreach(var genre in _context.Genres.Include(x => x.Titles))
                {
                    GenreDto g = new GenreDto
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    };
                    g.Titles = new List<string>();
                    foreach(var title in genre.Titles)
                    {
                        g.Titles.Add(_context.Titles.FirstOrDefault(x=>x.Id == title.TitleId).Name);
                    }
                    genres.Add(g);
                }

                return new CollectionResultDto<GenreDto>
                {
                    IsSuccessFull = true,
                    Result = genres
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessFull = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("remove")]
        public ResultDto RemoveGenre(int id)
        {
            try
            {
                var genre = _context.Genres.FirstOrDefault(f => f.Id == id);
                _context.Genres.Remove(genre);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccessFull = true
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessFull = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("add")]
        public ResultDto AddGenre(GenreDto genre)
        {
            try
            {
                if(_context.Genres.FirstOrDefault(x=> x.Name==genre.Name)!=null)
                {
                    return new ResultDto
                    {
                        IsSuccessFull = false,
                        Message = "Already exists"
                    };
                }
                Genre g = new Genre
                {
                    Name = genre.Name
                };

                _context.Genres.Add(g);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccessFull = true
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessFull = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("edit")]
        public ResultDto EditGenre(GenreDto genre)
        {
            try
            {
                Genre g = _context.Genres.FirstOrDefault(x => x.Id == genre.Id);
                g.Name = genre.Name;

                _context.Genres.Update(g);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccessFull = true
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessFull = false,
                    Message = ex.Message
                };
            }
        }
    }
}
