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
    public class TitleController : ControllerBase
    {
        private readonly EFContext _context;
        public TitleController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getTitle/{id}")]
        public ResultDto GetTitle([FromRoute] int id)
        {
            try
            {
                Title t = _context.Titles.Include(x=>x.Genres).Include(x=>x.Publisher).FirstOrDefault(x => x.Id == id);
                TitleDto title;
                List<string> genres;

                genres = new List<string>();

                foreach (var it in _context.TitleGenres)
                {
                    if (it.TitleId == t.Id)
                    {
                        genres.Add(_context.Genres.FirstOrDefault(x => x.Id == it.GenreId).Name);
                    }
                }
                title = new TitleDto
                {
                    Publisher = t.Publisher.Name,
                    Name = t.Name,
                    Genres = genres,
                    Description = t.Description,
                    Episodes = t.Episodes,
                    Id = t.Id,
                    Image = t.Image,
                    Rating = t.Rating,
                    Year = t.Year
                };
                return new SingleResultDto<TitleDto>
                {
                    IsSuccessFull = true,
                    Result = title
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

        [HttpGet]
        public ResultDto GetTitles()
        {
            try
            {
                List<TitleDto> titles = new List<TitleDto>();
                TitleDto title;
                List<string> genres;
                foreach (var item in _context.Titles.Include(x => x.Genres).Include(x => x.Publisher).ToList())
                {
                    genres = new List<string>();

                    foreach (var it in _context.TitleGenres)
                    {
                        if (it.TitleId == item.Id)
                        {
                            genres.Add(_context.Genres.FirstOrDefault(x => x.Id == it.GenreId).Name);
                        }
                    }
                    title = new TitleDto
                    {
                        Publisher = item.Publisher.Name,
                        Name = item.Name,
                        Genres = genres,
                        Description = item.Description,
                        Episodes = item.Episodes,
                        Id = item.Id,
                        Image = item.Image,
                        Rating = item.Rating,
                        Year = item.Year
                    };
                    titles.Add(title);
                }

                return new CollectionResultDto<TitleDto>
                {
                    IsSuccessFull = true,
                    Result = titles
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
        public ResultDto RemoveTitle(int id)
        {
            try
            {
                var title = _context.Titles.FirstOrDefault(f => f.Id == id);
                _context.Titles.Remove(title);
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
        public ResultDto AddTitle(TitleDto title)
        {
            try
            {
                if (_context.Publishers.FirstOrDefault(x => x.Name == title.Publisher) == null)
                {
                    _context.Publishers.Add(new Publisher { Name = title.Publisher });
                    _context.SaveChanges();
                }
                Title t = new Title
                {
                    Publisher = _context.Publishers.FirstOrDefault(x => x.Name == title.Publisher),
                    Name = title.Name,
                    Description = title.Description,
                    Episodes = title.Episodes,
                    Image = title.Image,
                    Rating = title.Rating,
                    Year = title.Year
                };

                foreach (var item in title.Genres)
                {
                    t.Genres.Add(new TitleGenre
                    {
                        GenreId = _context.Genres.FirstOrDefault(f => f.Name == item).Id,
                        TitleId = t.Id
                    });
                }
                _context.Titles.Add(t);
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
        public ResultDto EditTitle(TitleDto title)
        {
            try
            {
                Title t = new Title
                {
                    Id = title.Id,
                    Publisher = _context.Publishers.FirstOrDefault(x => x.Name == title.Publisher),
                    Name = title.Name,
                    Description = title.Description,
                    Episodes = title.Episodes,
                    Image = title.Image,
                    Rating = title.Rating,
                    Year = title.Year
                };

                foreach (var item in title.Genres)
                {
                    t.Genres.Add(new TitleGenre
                    {
                        GenreId = _context.Genres.FirstOrDefault(f => f.Name == item).Id,
                        TitleId = t.Id
                    });
                }

                _context.Titles.Update(t);
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
