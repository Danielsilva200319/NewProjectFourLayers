using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class StateDto : BaseDto
    {
        public string Name { get; set; }
        public int IdcountryFk { get; set; }
    }
}