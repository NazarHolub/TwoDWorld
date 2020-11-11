using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DTO.ResultDto
{
    public class CollectionResultDto<T> : ResultDto
    {
        public ICollection<T> Result { get; set; }
    }
}
