using Business;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Businesses", menuName = "Businesses", order = 0)]
    public class BusinessesConfig : ScriptableObject
    {
        [SerializeField] private BusinessModel[] _businessModels;
        public BusinessModel[] BusinessModels => _businessModels;
    }
}