using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum ColourType 
{
    Yellow, Pink
}

public class CarController : MonoBehaviour
{
    
    [SerializeField] private ColourType _type;
    [SerializeField] private CarMovementBehaviour _yellowCar;
    [SerializeField] private CarMovementBehaviour _pinkCar;
    [SerializeField] private List<ParkingLotBehaviour> _parkingLots;
    [SerializeField] private Transform _yellowCarInitialTransform;
    [SerializeField] private Transform _pinkCarInitialTransform;
    private GameManager _gameManager;
    private CarMovementBehaviour _currentYellowCar;
    private CarMovementBehaviour _currentPinkCar;
    public event Action<CarMovementBehaviour,ParkingLotBehaviour> OnCarArrivedToLot;

    public void Initialize(GameManager gameManager)
    {
        Debug.Log("Car Created");
        _gameManager = gameManager;
        _gameManager.ButtonBehaviour.OnGateOpened += GateOpened; // delegate
        CarCreator(0);
        CarCreator(1);
    }

    public void CarArrivedToLot(CarMovementBehaviour carMovementBehaviour,ParkingLotBehaviour parkingLotBehaviour)
    {
        OnCarArrivedToLot?.Invoke(carMovementBehaviour,parkingLotBehaviour);
    }

    private void CarCreator(int gateCode)
    {
        if (gateCode == 0)
        {
            
            var yellowCar = Instantiate(_yellowCar, _yellowCarInitialTransform.position, Quaternion.identity);
            yellowCar.Initialize(this);
            _currentYellowCar = yellowCar;
            //if (_currentYellowCar)
            //    return;
        }
        else
        {
           
            var pinkCar = Instantiate(_pinkCar, _pinkCarInitialTransform.position, Quaternion.identity);
            pinkCar.Initialize(this);
            _currentPinkCar = pinkCar;
            //if (_currentPinkCar)
            //    return;
        }
    }

    private void GateOpened(int gateCode) // have event gateCode 
    {
        CarCreator(gateCode);
        if (gateCode == 0)
        {
            var desiredLot = _parkingLots.Find(_parkingLots => _parkingLots.IsFulled != true);
            desiredLot.IsFulled = true;
            _currentYellowCar.CarMover(desiredLot);
        }
        else
        {
            var desiredLot = _parkingLots.Find(_parkingLots => _parkingLots.IsFulled != true);
            desiredLot.IsFulled = true;
            _currentPinkCar.CarMover(desiredLot);
        }
        

    }
}
