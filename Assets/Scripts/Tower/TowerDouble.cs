using System;
using UnityEngine;

public class TowerDouble : TowerBase
{
    [SerializeField] private GameObject _gunTwo;
    protected float _speedAttackTwo = 3;

    void Start()
    { }

    protected override void Update()
    {
        base.Update();
        Attack(Input.GetAxis("AttackTwo"));
    }

    private void Attack(float attack)
    {
        if (_speedAttackTwo >= 0)
            _speedAttackTwo -= Time.deltaTime;
        else
        {
            if (Math.Abs(attack - 1) > 0) return;
            var bullet = Instantiate(_bullet).GetComponent<Bullet>();
            bullet.Create(_gunTwo);
            _speedAttackTwo = SpeedAttack;
        }
    }
}