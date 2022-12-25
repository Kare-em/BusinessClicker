using System;
using System.Collections.Generic;
using Balance;
using Business;
using Configs;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private BusinessesConfig _businessConfig;
        [SerializeField] private TitlesConfig _titlesConfig;
        [SerializeField] private GameObject _businessPrefab;
        [SerializeField] private Transform _businesses;
        [SerializeField] private BalanceController _balanceController;
        private List<BusinessController> _businessControllers;
        private GameModel _model;
        private Loader _loader;
        private bool _loaded;


        private void Awake()
        {
            Application.targetFrameRate = 60;
            Load();
            Initialize();
        }

        private void Load()
        {
            _loader = new Loader();
            _model = _loader.TryLoad();
            _loaded = _model != null;
        }

        private void Initialize()
        {
            CreateGameModel();
            CreateBalance();
            CreateBusinesses();
        }

        private void CreateGameModel()
        {
            if (!_loaded)
            {
                _model = new GameModel();
                _model.Initialize();
            }
        }

        private void CreateBalance()
        {
            if (!_loaded)
                _model.SetBalanceModel(new BalanceModel());

            _balanceController.Initialize(_model.BalanceModel);
        }

        private void CreateBusinesses()
        {
            _businessControllers = new List<BusinessController>();
            

            for (int i = 0; i < _businessConfig.BusinessModels.Length; i++)
            {
                CreateBusiness(i);
            }
        }

        private void CreateBusiness(int i)
        {
            var business = Instantiate(_businessPrefab, _businesses);
            var businessController = business.GetComponent<BusinessController>();
            var businessModel = businessController.Initialize(_titlesConfig.Titles[i],
                _loaded ? _model.BusinessModels[i] : _businessConfig.BusinessModels[i],
                _balanceController);
            if (!_loaded && i == 0)
                businessController.SetStartLevel(1);
            businessController.onRevenue += _balanceController.OnRevenue;
            _businessControllers.Add(businessController);
            if (!_loaded)
                _model.BusinessModels.Add(businessModel);
            else
                _model.SetBusinessModel(businessModel, i);
        }


        private void OnDestroy()
        {
            foreach (var businessController in _businessControllers)
            {
                businessController.onRevenue -= _balanceController.OnRevenue;
            }
        }
        
        private void OnApplicationQuit()
        {
            _loader.Save(_model);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if(pauseStatus)
                _loader.Save(_model);
        }
    }
}