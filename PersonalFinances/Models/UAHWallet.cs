namespace PersonalFinances
{
    class UAHWallet : Wallet
    {
        public UAHWallet(string name, double balance)
        : base(name, "UAH", balance)
        {
        }
    }
}