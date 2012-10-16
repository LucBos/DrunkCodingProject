using NUnit.Framework;

namespace MyAI
{
    [TestFixture]
    public class A_new_circle
    {
        private Circle _circle;

        [SetUp]
        public void Setup()
        {
            _circle = new Circle(3,3, 2);
        }

        [TestCase(6, 4, 1, Result = false)]
        [TestCase(5, 4, 1, Result = true)]
        [TestCase(6, 4, 2, Result = true)]
        [TestCase(1, 7, 1, Result = false)]
        [TestCase(1, 7, 2, Result = false)]
        [TestCase(1, 7, 3, Result = true)]
        public bool Given_another_circle_it_can_determin_wether_the_2_circles_intersect(int x, int y, int radius)
        {
            var otherCircle = new Circle(x, y, radius);
            return _circle.Intersects(otherCircle);
        }
    }
}