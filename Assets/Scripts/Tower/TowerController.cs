using System;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;

    private int _currentTower;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            NextTower();
        if (Input.GetKeyDown(KeyCode.Q))
            PreviousTower();
    }

    private void NextTower()
    {
        _towers[_currentTower].SetActive(false);
        _currentTower = ++_currentTower%3;
        _towers[_currentTower].SetActive(true);
    }

    private void PreviousTower()
    {
        _towers[_currentTower].SetActive(false);
        _currentTower = --_currentTower;
        if (_currentTower < 0)
            _currentTower += 3;
        _towers[_currentTower].SetActive(true);
    }
}