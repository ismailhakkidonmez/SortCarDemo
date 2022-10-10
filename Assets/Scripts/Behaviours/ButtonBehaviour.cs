using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{
    public event Action<int> OnGateOpened;
    public bool IsYellowGateOpen;
    public bool IsPinkGateOpen;

    [SerializeField] private Button _buttonYellow;
    [SerializeField] private Button _buttonPink;

    [SerializeField] GateBehaviour _yellowGate;
    [SerializeField] GateBehaviour _pinkGate;

    private GameManager _gameManager;
    public void Initialize(GameManager gameManager)
    {
        _buttonYellow.onClick.AddListener(YellowButtonClicked);
        _buttonPink.onClick.AddListener(PinkButtonClicked);
        _gameManager = gameManager;

    }

    public void YellowButtonClicked()
    {
        if (_yellowGate.IsGateBusy)
             return;
        _yellowGate.OpenGate();
        OnGateOpened?.Invoke(0);
    }

    public void PinkButtonClicked()
    {
        if (_pinkGate.IsGateBusy)
            return;
        _pinkGate.OpenGate();
        OnGateOpened?.Invoke(1);
    }


}
