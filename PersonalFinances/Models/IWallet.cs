namespace PersonalFinances
{
    internal interface IWallet
    {
        void Withdraw(double sum);
        void Replenish(double sum);
    }
}