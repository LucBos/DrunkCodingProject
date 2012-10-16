namespace MyAI
{
    public class Player
    {
        private const int ExtraCargoAfterCargoUpgrade = 1;
        private const int ExtrHealthAfterHealthUpgrade = 2;
        private const int ExtraAttackAfterWeaponsUpgrade = 1;
        private const int CostForCargoUpgrade = 2;
        private const int CostOfHealthUpgrade = 5;
        private const int CostOfWeaponUpgrade = 5;
        private const int NatureUpperBound = 100;

        public Player(IRandom random)
        {
            Health = 10;
            Attack = 3;
            Cargo = 1;
            Nature = random.Get(NatureUpperBound);
        }

        public int Health { get; set; }

        public int Attack { get; set; }

        public int Cargo { get; set; }

        public int Nature { get; set; }

        public int AggregatedContacts
        {
            get { return 0; }
        }

        public int NrOfTradesDone { get; set; }

        public int NrOfSchipsPirated { get; set; }

        public int NrOfSchipsDefended { get; set; }

        public int NrOfTimesAttacked { get; set; }

        public int Money { get; set; }

        public void UpgradeWeapons()
        {
            if (HasSufficientFundsForWeaponsUpgrade())
            {
                Attack = Attack + ExtraAttackAfterWeaponsUpgrade;
                Money = Money - CostOfWeaponUpgrade;
            }
        }

        private bool HasSufficientFundsForWeaponsUpgrade()
        {
            return Money >= CostOfWeaponUpgrade;
        }

        public void UpgradeHealth()
        {
            if (HasSufficientFundsForHealthUpgrade())
            {
                Health = Health + ExtrHealthAfterHealthUpgrade;
                Money = Money - CostOfHealthUpgrade;
            }
        }

        private bool HasSufficientFundsForHealthUpgrade()
        {
            return Money >= CostOfHealthUpgrade;
        }

        public void UpgradeCargo()
        {
            if (HasSufficientFundsForCargoUpgrade())
            {
                Cargo = Cargo + ExtraCargoAfterCargoUpgrade;
                Money = Money - CostForCargoUpgrade;
            }
        }

        private bool HasSufficientFundsForCargoUpgrade()
        {
            return Money >= CostForCargoUpgrade;
        }
    }
}