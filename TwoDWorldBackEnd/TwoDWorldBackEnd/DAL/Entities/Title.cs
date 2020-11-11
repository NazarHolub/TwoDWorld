using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DAL.Entities
{
    public class Title
    {
        public Title()
        {
            Genres = new List<TitleGenre>();
        }
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Episodes { get; set; }
        [Required]
        public int Year { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public virtual ICollection<TitleGenre> Genres { get; set; }


    }
}
