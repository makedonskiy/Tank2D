using System;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] protected GameObject _gun;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float SpeedAttack;
    protected float _speedAttack = 3;

    void Start()
    {

    }

    protected virtual void Update()
    {
        Attack(Input.GetAxis("Attack"));
    }

    private void Attack(float attack)
    {
        if (_speedAttack >= 0)
            _speedAttack -= Time.deltaTime;
        else
        {
            if (Math.Abs(attack - 1) > 0) return;
            var bullet = Instantiate(_bullet).GetComponent<Bullet>();
            bullet.Create(_gun);
            _speedAttack = SpeedAttack;
        }
    }
}