using System.Drawing;
using System.Linq;

namespace MyAI
{
    internal class PlanetGenerator
    {
        private readonly IMap _map;
        private readonly IRandom _random;

        public PlanetGenerator(IMap map, IRandom random)
        {
            _map = map;
            _random = random;
            MaximumMapSize = new Size(10000,10000);
            MaximumPlanetSize = 250;
        }

        public int MaximumPlanetSize { get; set; }

        public Size MaximumMapSize { get; set; }

        public void GeneratePlanets(int nrOfPlanets)
        {
            for (int i = 0; i < nrOfPlanets; i++)
            {

                Circle circle;

                do
                {
                    circle = GeneratePlanetCircle();
                } while (circle.IntersectsWithAny(_map.Planets.Select(x => x.Circle)));

                _map.AddPlanet(new Planet(circle));
            }
        }

        private Circle GeneratePlanetCircle()
        {
            return new Circle(_random.Get(MaximumMapSize.Width), _random.Get(MaximumMapSize.Height),
                                _random.Get(MaximumPlanetSize));
        }
    }
}