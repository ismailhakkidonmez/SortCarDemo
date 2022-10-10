using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private List<Canvas> _panels;
    private GameManager _gameManager;

    public void Initialize(GameManager game)
    {
        for (int i = 0; i < _panels.Count; i++) //close panels;
        {
            _panels[i].gameObject.SetActive(false);
        }

    }
}
