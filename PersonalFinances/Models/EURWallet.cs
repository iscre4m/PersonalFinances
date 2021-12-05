namespace PersonalFinances
{
    class EURWallet : Wallet
    {
        public EURWallet(string name, double balance)
        : base(name, "EUR", balance)
        {
        }
    }
}