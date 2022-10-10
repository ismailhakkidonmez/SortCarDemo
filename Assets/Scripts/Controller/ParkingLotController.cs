using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkingLotController : MonoBehaviour
{
    [SerializeField] private List<ParkingLotBehaviour> _parkingLots;
    private GameManager _gameManager;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        for (int i = 0; i < _parkingLots.Count; i++)
        {
            _parkingLots[i].Initialize(gameManager);
        }
        _gameManager.CarController.OnCarArrivedToLot += CheckMatchingColors;

    }
    public void CheckMatchingColors(CarMovementBehaviour carMovementBehaviour, ParkingLotBehaviour parkingLotBehaviour)
    {
        _gameManager.CarController.OnCarArrivedToLot -= CheckMatchingColors;


        if (carMovementBehaviour.Type == parkingLotBehaviour.Type)
        {
            parkingLotBehaviour.IsMatchSuccess = true;
            Debug.Log("Match Success");
            parkingLotBehaviour.Canvas.SetActive(true);
        }
        else
        {
            Debug.Log("Match Failed");
            SceneManager.LoadScene(0);
        }
        _gameManager.CarController.OnCarArrivedToLot += CheckMatchingColors;
    }

}
