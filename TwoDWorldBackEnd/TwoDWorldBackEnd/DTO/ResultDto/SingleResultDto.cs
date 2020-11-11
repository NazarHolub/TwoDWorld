using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DTO.ResultDto
{
    public class SingleResultDto<T> : ResultDto
    {
        public T Result { get; set; }
    }
}
