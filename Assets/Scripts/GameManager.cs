using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ButtonBehaviour ButtonBehaviour => _buttonBehaviour;
    //public BarriersManager BarriersManager => _barriersManager;
    //public ButtonManager ButtonManager => _buttonManager;
    public CarController CarController => _carController;
    public PanelController PanelController => _panelController;
    public ParkingLotController ParkingLotController => _parkingLotController;
    //public EventManager EventManager => _eventManager;

    [SerializeField] private ButtonBehaviour _buttonBehaviour;
    //[SerializeField] private BarriersManager _barriersManager;
    //[SerializeField] private ButtonManager _buttonManager;
    [SerializeField] private CarController _carController;
    [SerializeField] private PanelController _panelController;
    [SerializeField] private ParkingLotController _parkingLotController;
    //[SerializeField] private EventManager _eventManager;


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {

        _buttonBehaviour.Initialize(this);
        //_barriersManager.Initialize(this);
        //_buttonManager.Initialize(this);
        _carController.Initialize(this);
        _panelController.Initialize(this);
        _parkingLotController.Initialize(this);
        //_eventManager.Initialize(this);
    }
}
