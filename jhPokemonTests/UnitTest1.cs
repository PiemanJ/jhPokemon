using System;
using Xunit;

namespace jhPokemon.Tests
{
    public class UnitTest1
    {
        #region PokemonGet tests

        #region PokemonGet "ditto" tests

        [Fact]
        public void PokemonGet_ditto_Name()
        {
            // arrange
            var action = new jhPokemon.Controllers.PokemonsController();

            // act
            var result = action.Get("ditto");

            // assert
            Assert.Equal("ditto", result.Name);
        }

        [Fact]
        public void PokemonGet_ditto_IsLegendary()
        {
            // arrange
            var action = new jhPokemon.Controllers.PokemonsController();

            // act
            var result = action.Get("ditto");

            // assert
            Assert.False(result.IsLegendary);
        }

        [Fact]
        public void PokemonGet_ditto_Habitat()
        {
            // arrange
            var action = new jhPokemon.Controllers.PokemonsController();

            // act
            var result = action.Get("ditto");

            // assert
            Assert.Equal("urban", result.Habitat);
        }


        #endregion

        #region PokemonGet "mewtwo" tests

        [Fact]
        public void PokemonGet_mewtwo_mewtwo()
        {
            // arrange
            var action = new jhPokemon.Controllers.PokemonsController();

            // act
            var result = action.Get("mewtwo");

            // assert
            Assert.Equal("mewtwo", result.Name);
            Assert.Equal("rare", result.Habitat);
            Assert.True(result.IsLegendary);
        }

        #endregion

        #region PokemonGetTranslated "mewtwo" tests

        [Fact]
        public void PokemonGetTranslated_mewtwo_Name()
        {
            // arrange
            var action = new jhPokemon.Controllers.PokemonsController();

            // act
            var result1 = action.Get("mewtwo");
            var result2 = action.GetTranslated("mewtwo");

            // asserts that the translated and untranslated Descriptions differ
            Assert.NotEqual(result1.Description, result2.Description);
        }

        #endregion

        #endregion

    }
}
