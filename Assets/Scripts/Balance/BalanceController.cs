using System;
using System.Collections.Generic;
using UnityEngine;

namespace Balance
{
    public class BalanceController : MonoBehaviour
    {
        private BalanceModel _balanceModel;
        private BalanceView _balanceView;

        public void Initialize(BalanceModel balanceModel)
        {
            _balanceModel = balanceModel;
            _balanceView = GetComponent<BalanceView>();
            _balanceView.UpdateBalance(_balanceModel.Balance);
        }

        public bool TrySpendMoney(float money)
        {
            if (_balanceModel.UpdateBalance(-money))
            {
                _balanceView.UpdateBalance(_balanceModel.Balance);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnRevenue(float money)
        {
            _balanceModel.UpdateBalance(money);
            _balanceView.UpdateBalance(_balanceModel.Balance);
        }

    }
}