using NUnit.Framework;

namespace MyAI
{
    public class A_player
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player(new RandomGenerator());

        }

        [Test]
        public void Should_have_extra_attack_after_upgrading_weapons()
        {
            _player.Attack = 1;
            _player.Money = 5;

            _player.UpgradeWeapons();

            Assert.Greater( _player.Attack,1);
        }

        [Test]
        public void Should_not_be_able_to_upgrade_weapons_if_money_is_insufficient()
        {
            _player.Attack = 1;
            _player.Money = 0;

            _player.UpgradeWeapons();

            Assert.AreEqual(1, _player.Attack);
        }

        [Test]
        public void Should_have_money_subtracted_when_upgrading_weapons()
        {
            _player.Money = 10;

            _player.UpgradeWeapons();

            Assert.Less(_player.Money, 10);
        }


        [Test]
        public void Should_have_extra_health_after_upgrading_health()
        {
            _player.Health = 1;
            _player.Money = 5;

            _player.UpgradeHealth();

            Assert.Greater(_player.Health,1);
        }

        [Test]
        public void Should_not_be_able_to_upgrade_health_if_money_is_insufficient()
        {
            _player.Health= 1;
            _player.Money = 0;

            _player.UpgradeHealth();

            Assert.AreEqual(1, _player.Health);
        }

        [Test]
        public void Should_have_money_subtracted_when_upgrading_health()
        {
            _player.Money = 10;

            _player.UpgradeHealth();

            Assert.Less(_player.Money, 10);
        }

        [Test]
        public void Should_have_extra_cargo_after_upgrading_cargo()
        {
            _player.Cargo = 1;
            _player.Money = 5;

            _player.UpgradeCargo();

            Assert.Greater(_player.Cargo, 1);
        }

        [Test]
        public void Should_not_be_able_to_upgrade_cargo_if_money_is_insufficient()
        {
            _player.Cargo = 1;
            _player.Money = 0;

            _player.UpgradeCargo();

            Assert.AreEqual(1, _player.Cargo);
        }

        [Test]
        public void Should_have_money_subtracted_when_upgrading_cargo()
        {
            _player.Money = 10;

            _player.UpgradeCargo();

            Assert.Less(_player.Money, 10);
        }
    }
}
