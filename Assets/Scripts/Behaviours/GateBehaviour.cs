using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    public bool IsGateBusy => _isGateBusy;
    [SerializeField] private bool _isReverseGate;

    private bool _isGateOpening;
    private bool _isGateBusy;

    private void Update()
    {
        if (_isGateOpening)
        {
            if (_isReverseGate)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
        }
    }

    public void OpenGate()
    {
        if(_isGateBusy == true)
        {
            return;
        }
        _isGateOpening = true;
        _isGateBusy = true;
        StartCoroutine(GateCloserCo());
    }

    private IEnumerator GateCloserCo()
    {
        yield return new WaitForSeconds(.5f);
        _isGateOpening = false;
        yield return new WaitForSeconds(1f);
        _isGateBusy = false;

    }
}
