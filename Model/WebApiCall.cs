using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhPokemon.Model
{
    public class WebApiCallResponse
    {
        public int HttpStatusCode { get; set; } = 0;
        public string ResponseBody { get; set; } = string.Empty;

    }

}
