using NUnit.Framework;

namespace MyAI
{
    public class A_new_SpaceObject_with_a_certain_mass_and_no_vertical_speed
    {
        private SpaceObject _spaceObject;

        [SetUp]
        public void Setup()
        {
            _spaceObject = new SpaceObject() { Mass = 100 };
        }

        [Test]
        public void When_no_propulsion_is_added_it_should_remain_still()
        {
            Assert.AreEqual(0, _spaceObject.Speed);
        }

        [Test]
        public void When_horizontal_force_is_added_it_will_move_with_an_incremental_speed_by_the_law_of_newton()
        {
            _spaceObject.ApplyHorizontalForce(10, 2);

            Assert.AreEqual(5, _spaceObject.Speed);
        }

        [Test]
        public void Given_it_is_already_moving_at_a_certain_speed_when_a_horizontal_force_is_applied_it_will_move_with_an_incremental_speed_by_the_law_of_newton()
        {
            _spaceObject.HorizonalSpeed = 50;
            _spaceObject.ApplyHorizontalForce(10, 2);

            Assert.AreEqual(55, _spaceObject.Speed);
        }

        [Test]
        public void Given_no_horizontal_force_is_applied_it_should_remain_at_the_same_speed()
        {
            _spaceObject.HorizonalSpeed = 50;
            _spaceObject.ApplyHorizontalForce(0, 2);

            Assert.AreEqual(50, _spaceObject.Speed);
        }

        [Test]
        public void Give_a_horizontal_force_is_applied_but_with_zero_seconds_it_should_remain_at_the_same_speed()
        {
            _spaceObject.HorizonalSpeed = 50;
            _spaceObject.ApplyHorizontalForce(100, 0);

            Assert.AreEqual(50, _spaceObject.Speed);
        }
    }
}