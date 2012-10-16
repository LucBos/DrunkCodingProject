using System.Collections.Generic;
using System.Linq;

namespace MyAI
{
    public class MapSpy
    {
        private IEnumerable<object> _planets;
        private IEnumerable<Player> _players;

        public void SetPlanets(IEnumerable<object> planets)
        {
            _planets = planets;
        }

        public void SetPlayers(IEnumerable<Player> players)
        {
            _players = players;
        }

        public int NrOfPlanets
        {
            get { return _planets.Count(); }
        }

        public int NrOfPlayers
        {
            get { return _players.Count(); }
        }
    }
}