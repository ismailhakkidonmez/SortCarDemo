using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class CarMovementBehaviour : MonoBehaviour
{
    //public Vector3 StartPos;
    //public Vector3 targetPosition;
    //public float speed = 10;
    public ColourType Type => _type;
    [SerializeField] private ColourType _type;
    private CarController _carController;
    private Vector3 _desiredLocation;

    //private void Awake()
    //{
    //    StartPos = gameObject.transform.position;
    //}
    //void Update()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //}

    public void Initialize(CarController carController)
    {
        _carController = carController;
    }
    public void CarMover(ParkingLotBehaviour parkingLotDesiredLocation)
    {
        _desiredLocation = parkingLotDesiredLocation.transform.position;
        //Debug.Log("car arrived");
        transform.DOMove(_desiredLocation, 2f).OnComplete(() => { _carController.CarArrivedToLot(this, parkingLotDesiredLocation); Debug.Log("Car arrived"); }) ;
    }


}


