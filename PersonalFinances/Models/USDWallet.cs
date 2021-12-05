namespace PersonalFinances
{
    class USDWallet : Wallet
    {
        public USDWallet(string name, double balance)
            : base(name, "USD", balance)
        {
        }
    }
}