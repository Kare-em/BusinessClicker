using System;
using Balance;
using Structures;
using UnityEngine;
using UnityEngine.UI;

namespace Business
{
    public class BusinessController : MonoBehaviour
    {
        private BusinessModel _businessModel;
        private Button _levelUpButton;

        private BusinessView _businessView;
        private BalanceController _playerController;
        public Action<float> onRevenue;


        public BusinessModel Initialize(Titles titles, BusinessModel businessModel,
            BalanceController playerController)
        {
            _playerController = playerController;
            _businessModel = (BusinessModel)businessModel.Clone();
            _businessModel.SetNames(titles);

            _businessView = GetComponent<BusinessView>();
            UpdateView();
            return _businessModel;
        }
        public void SetStartLevel(int i)
        {
            _businessModel.SetStartLevel(i);
            UpdateView();
        }

        public void Upgrade(int i)
        {
            if (_businessModel.CurrentLevel > 0)
            {
                if (_playerController.TrySpendMoney(_businessModel.Upgrades[i].Price))
                {
                    _businessModel.Upgrade(i);
                    UpdateView();
                }
            }
        }

        public void LevelUp()
        {
            if (_playerController.TrySpendMoney(_businessModel.LevelCost))
            {
                _businessModel.LevelUpgrade();
                UpdateView();
            }
        }
        private void UpdateView()
        {
            _businessView.UpdateMainInfo(
                _businessModel.Name,
                _businessModel.CurrentLevel,
                _businessModel.CurrentRevenue,
                _businessModel.LevelCost);
            _businessView.UpdateUpgradesInfo(_businessModel.Upgrades);
            _businessView.SetMaxProgress(_businessModel.TimeDelay);
        }
        
        private void Update()
        {
            if (_businessModel.CurrentLevel > 0)
                ProgressUpdate();
        }

        private void ProgressUpdate()
        {
            _businessModel.RevenueUpdate(Time.unscaledDeltaTime);
            if (_businessModel.RevenueProgress >= _businessModel.TimeDelay)
            {
                _businessModel.ResetProgress();
                onRevenue.Invoke(_businessModel.CurrentRevenue);
            }

            _businessView.UpdateProgress(_businessModel.RevenueProgress);
        }
        
        

        
    }
}