using Structures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Business
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private Slider _progress;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _revenue;
        [SerializeField] private TMP_Text _lvlUpCost;
        [SerializeField] private TMP_Text[] _upgrade;
        [SerializeField] private Button[] _upgradeButtons;

        public void UpdateMainInfo(string businessModelName, int lvl, float revenue, float lvlUpCost)
        {
            _name.text = businessModelName;
            _lvl.text = lvl.ToString();
            _revenue.text = revenue.ToString()+'$';
            _lvlUpCost.text = "LVL UP\nЦена: " + lvlUpCost + '$';
        }

        public void UpdateUpgradesInfo(Upgrade[] upgrades)
        {
            for (int i = 0; i < _upgrade.Length; i++)
            {
                _upgrade[i].text = upgrades[i].GetInfo();
                _upgradeButtons[i].interactable = !upgrades[i].Enabled;
            }
        }

        public void SetMaxProgress(float maxProgress)
        {
            _progress.maxValue = maxProgress;
        }

        public void UpdateProgress(float revenueProgress)
        {
            _progress.value = revenueProgress;
        }
    }
}