using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Structures
{
    [Serializable]
    public struct Upgrade
    {
        [SerializeField] private int _price;
        [SerializeField] private int _revenueRatio;

        [HideInInspector] public bool Enabled;
        public string Name { get; set; }
        public int Price => _price;
        public int RevenueRatio => _revenueRatio;

        public string GetInfo()
        {
            return Name + '\n' +
                   "Доход: +" + _revenueRatio + '%' + '\n' +
                   (Enabled ? "Куплено" : "Цена: " + _price);
        }
    }
}