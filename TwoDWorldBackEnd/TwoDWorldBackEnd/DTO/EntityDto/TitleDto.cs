using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DTO.EntityDto
{
    public class TitleDto
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        public int Episodes { get; set; }

        public int Year { get; set; }

        public string Publisher { get; set; }

        public virtual List<string> Genres { get; set; }
    }
}
