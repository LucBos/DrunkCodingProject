using System;
using System.Collections.Generic;
using System.Drawing;
using Moq;
using NUnit.Framework;

namespace MyAI
{
    public class A_new_PlanetGenerator
    {
        private PlanetGenerator _planetGenerator;
        private Mock<IMap> _map;
        private RandomGenerator _random;

        [SetUp]
        public void Setup()
        {
            _map = new Mock<IMap>();
            _random = new RandomGenerator();
            _planetGenerator = new PlanetGenerator(_map.Object, _random);
        }

        [Test]
        public void Given_a_nr_of_planets_when_GeneratePlanets_is_called_it_should_add_planets_to_the_a_map()
        {
            _planetGenerator.GeneratePlanets(10);

            _map.Verify(x => x.AddPlanet(It.IsAny<Planet>()), Times.Exactly(10));
        }

        [Test]
        public void
            Given_a_nr_of_planets_when_GeneratePlanets_is_called_each_planet_generated_should_have_a_different_location()
        {
            _planetGenerator.GeneratePlanets(10);

            var previousCircles = new List<Circle>();

            _map.Verify(x => x.AddPlanet(It.Is<Planet>(planet => planet.Circle.NotIntersectWithAny(previousCircles))));
        }

        [Test]
        public void Given_a_maximum_planet_size_when_GeneratePlanets_is_called_no_planet_should_have_a_bigger_radius_than_the_maximum_size()
        {
            _planetGenerator.MaximumPlanetSize = 50;

            _planetGenerator.GeneratePlanets(10);

            _map.Verify(x => x.AddPlanet(It.Is<Planet>(planet => planet.Circle.Radius <= 50)));
        }

        [Test]
        public void Given_a_maximum_map_size_when_GeneratePlanets_is_called_planets_should_fall_within_that_range()
        {
            _planetGenerator.MaximumMapSize = new Size(1111, 2222);

            _planetGenerator.GeneratePlanets(10);

            _map.Verify(x => x.AddPlanet(It.Is<Planet>(planet => planet.Circle.X <= 1111 && planet.Circle.Y <= 2222)));
        }

        [Test]
        public void The_default_map_size_should_be_10000x10000()
        {
            _planetGenerator.GeneratePlanets(10);

            _map.Verify(x => x.AddPlanet(It.Is<Planet>(planet => planet.Circle.X <= 10000 && planet.Circle.Y <= 10000)));

        }

        [Test]
        public void The_default_planet_size_should_be_250()
        {
            _planetGenerator.GeneratePlanets(10);
            
            _map.Verify(x => x.AddPlanet(It.Is<Planet>(planet => planet.Circle.Radius <= 250)));

        }
    }
}