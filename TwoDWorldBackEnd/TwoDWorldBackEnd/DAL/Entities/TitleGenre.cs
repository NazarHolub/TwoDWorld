using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DAL.Entities
{
    public class TitleGenre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int TitleId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Title Title { get; set; }
    }
}
