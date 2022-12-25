using System;

namespace Balance
{
    [Serializable]
    public class BalanceModel
    {
        private float _balance;
        public float Balance => _balance;

        public bool UpdateBalance(float money)
        {
            if (_balance + money >= 0f)
            {
                _balance += money;
                return true;
            }

            return false;
        }
    }
}