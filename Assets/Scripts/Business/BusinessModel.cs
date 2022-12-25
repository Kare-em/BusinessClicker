using System;
using Structures;
using Unity.VisualScripting;
using UnityEngine;

namespace Business
{
    [Serializable]
    public class BusinessModel : ICloneable
    {
        [SerializeField] private int _startLevel;
        [SerializeField] private float _timeDelay;
        [SerializeField] private float _baseCost;
        [SerializeField] private float _baseRevenue;

        [SerializeField] private Upgrade[] _upgrades;
        private int _currentLevel;
        public int CurrentLevel { get; private set; }

        public string Name => _name;
        public float TimeDelay => _timeDelay;
        public float LevelCost => (CurrentLevel + 1) * _baseCost;
        public Upgrade[] Upgrades => _upgrades;
        public float CurrentRevenue => CurrentLevel * _baseRevenue * (1 + 0.01f * AccessibleUpgrades());

        private string _name;
        private float _revenueProgress;
        public float RevenueProgress => _revenueProgress;

        public object Clone()
        {
            var copy = this.Serialize();
            return copy.Deserialize();
        }

        public void SetStartLevel(int i)
        {
            CurrentLevel = i;
        }

        public void SetNames(Titles titles)
        {
            _name = titles.BusinessName;
            for (int i = 0; i < _upgrades.Length; i++)
            {
                _upgrades[i].Name = titles.UpgradesName[i];
            }
        }

        public void LevelUpgrade()
        {
            CurrentLevel++;
        }

        public void Upgrade(int i)
        {
            _upgrades[i].Enabled = true;
        }

        public void RevenueUpdate(float deltaTime)
        {
            _revenueProgress += deltaTime;
        }

        public void ResetProgress()
        {
            _revenueProgress = 0;
        }


        private float AccessibleUpgrades()
        {
            float totalUpgrade = 0f;
            foreach (var upgrade in _upgrades)
            {
                totalUpgrade += upgrade.Enabled ? upgrade.RevenueRatio : 0;
            }

            return totalUpgrade;
        }
    }
}