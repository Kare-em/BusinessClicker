using System;
using System.Collections.Generic;
using Balance;
using Business;

namespace Game
{
    [Serializable]
    public class GameModel
    {
        public BalanceModel BalanceModel { get; private set; }
        public List<BusinessModel> BusinessModels{ get; private set; }

        public void Initialize()
        {
            BusinessModels = new List<BusinessModel>();
        }
        public void SetBalanceModel(BalanceModel balanceModel)
        {
            BalanceModel = balanceModel;
        }
        public void AddBusinessModel(BusinessModel businessModel)
        {
            BusinessModels.Add(businessModel);
        }
        public void SetBusinessModel(BusinessModel businessModel,int index)
        {
            BusinessModels[index] = businessModel;
        }
    }
}