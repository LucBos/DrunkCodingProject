using Moq;
using NUnit.Framework;

namespace MyAI
{
    public class A_new_player
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player(new RandomGenerator());
        }

        [Test]
        public void Should_have_a_default_health_of_10()
        {
            Assert.AreEqual(10, _player.Health);
        }

        [Test]
        public void Should_have_a_default_attack_of_3()
        {
            Assert.AreEqual(3, _player.Attack);
        }

        [Test]
        public void Should_have_a_default_cargo_of_1()
        {
            Assert.AreEqual(1, _player.Cargo);
        }

        [Test]
        public void Should_have_a_default_money_of_0()
        {
            Assert.AreEqual(0, _player.Money);
        }

        [Test]
        public void Should_have_a_random_nature_assigned_to_it_between_0_and_100()
        {
            var randomMock = new Mock<IRandom>();
            randomMock.Setup(x => x.Get(100)).Returns(60);

            var player = new Player(randomMock.Object);

            Assert.AreEqual(60, player.Nature);
        }

        [Test]
        public void Should_not_have_contacts_on_planets()
        {
            Assert.AreEqual(0, _player.AggregatedContacts);
        }

        [Test]
        public void Should_have_no_trades_done()
        {
            Assert.AreEqual(0, _player.NrOfTradesDone);
        }

        [Test]
        public void Should_have_no_schips_pirated()
        {
            Assert.AreEqual(0, _player.NrOfSchipsPirated);
        }

        [Test]
        public void Should_have_no_schips_defended()
        {
            Assert.AreEqual(0, _player.NrOfSchipsDefended);
        }

        [Test]
        public void Should_have_not_been_attacked()
        {
            Assert.AreEqual(0, _player.NrOfTimesAttacked);
        }
    }
}