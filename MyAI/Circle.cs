using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAI
{
    public class Circle
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _radius;

        public Circle(int x, int y, int radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public decimal Radius
        {
            get { return _radius; }
        }

        public decimal X { get { return _x; }  }

        public decimal Y { get { return _y; } }

        public bool Intersects(Circle circle)
        {
            var dx = circle._x - _x;
            var dy = circle._y - _y;
            var distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            return (distance < _radius + circle._radius);
        }

        public bool NotIntersectWithAny(List<Circle> previousCircles)
        {
            return !IntersectsWithAny(previousCircles);
        }

        public bool IntersectsWithAny(IEnumerable<Circle> previousCircles)
        {
            return previousCircles.Any(x => x.Intersects(this));
        }
    }
}