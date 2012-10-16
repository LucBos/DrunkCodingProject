using NUnit.Framework;

namespace MyAI
{
    class A_new_Map
    {
        private Map _map;
        private MapSpy _spy;

        [SetUp]
        public void Setup()
        {
            _spy = new MapSpy();
            _map = new Map(_spy);
        }
        
        [Test]
        public void Can_have_a_planet_added_to_it()
        {
            _map.AddPlanet(new Planet(new Circle(0,0,0)));
            Assert.AreEqual(1, _spy.NrOfPlanets);
        }

        [Test]
        public void Can_have_players_added_to_it()
        {
            _map.AddPlayer(new Player(new RandomGenerator()));

            Assert.AreEqual(_spy.NrOfPlayers, 1);
        }
    }
}
