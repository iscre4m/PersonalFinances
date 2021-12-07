namespace PersonalFinances
{
    internal interface IWalletModel
    {
        void Withdraw(double sum);
        void Replenish(double sum);
    }
}