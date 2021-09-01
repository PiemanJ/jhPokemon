using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using jhPokemon.DTO;

namespace jhPokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Core.NullResponseFilter]
    public class PokemonsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<DTO.PokemonBasicDto> Get()
        {
            // return a list of fake Pokemons as a test
            return new List<DTO.PokemonBasicDto>
            {
                new PokemonBasicDto { Name = "mewtwo", Description = "blah", Habitat = "rare", IsLegendary = true }, 
                new PokemonBasicDto { Name = "thing", Description = "blah blah", Habitat = "cave", IsLegendary = false }
            };
        }

        [HttpGet("{name}")]
        public DTO.PokemonBasicDto Get(string name)
        {
            PokemonBasicDto result = Mapper.Map(PokeApi.GetPokemonFromApi(name));

            // TODO: hook up action filter to return a 404 error if not found
            return result;
        }

        [HttpGet("translated/{name}")]
        public DTO.PokemonBasicDto GetTranslated(string name)
        {
            PokemonBasicDto result = Mapper.Map(PokeApi.GetPokemonFromApi(name, true));



            // TODO: hook up action filter to return a 404 error if not found
            return result;
        }

     }
}
