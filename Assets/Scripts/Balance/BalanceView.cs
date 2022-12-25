using TMPro;
using UnityEngine;

namespace Balance
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balance;

        public void UpdateBalance(float money)
        {
            _balance.text = "Баланс: " + money + "$";
        }
    }
}