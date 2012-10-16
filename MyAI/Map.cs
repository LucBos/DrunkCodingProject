using System.Collections.Generic;
using System.Linq;

namespace MyAI
{
    public interface IMap
    {
        void AddPlanet(Planet planet);
        void AddPlayer(Player player);

        IEnumerable<Planet> Planets { get; }
    }

    public class Map : IMap
    {
        private readonly MapSpy _spy;
        private List<Planet> _planets = new List<Planet>();
        private List<Player> _players = new List<Player>();

        public Map(MapSpy spy)
        {
            _spy = spy;
            _spy.SetPlanets(_planets);
            _spy.SetPlayers(_players);
        }

        public void AddPlanet(Planet planet)
        {
            _planets.Add(planet);
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public IEnumerable<Planet> Planets
        {
            get { return _planets; }
        }
    }
}