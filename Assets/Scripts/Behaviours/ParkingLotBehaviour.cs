using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingLotBehaviour : MonoBehaviour
{
    public bool IsFulled;
    public bool IsMatchSuccess;
    public ColourType Type => _type;
    public GameObject Canvas => _canvas;
    [SerializeField] private ColourType _type;
    [SerializeField] private GameObject _canvas;
    private GameManager _gameManager;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        //_gameManager.CarController.OnCarArrivedToLot += CheckMatchingColors;
    
    }


    //public void CheckMatchingColors(CarMovementBehaviour carMovementBehaviour,ParkingLotBehaviour parkingLotBehaviour)
    //{
    //    _gameManager.CarController.OnCarArrivedToLot -= CheckMatchingColors;


    //    if (carMovementBehaviour.Type == parkingLotBehaviour._type)
    //    {
    //        IsMatchSuccess = true;
    //        Debug.Log("Match Success");
    //    }
    //    else
    //    {
    //        Debug.Log("Match Failed");
    //    }

    //}



}
