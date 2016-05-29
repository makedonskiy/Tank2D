using System;
using UnityEngine;
using System.Collections;

public class Monster : LiveObject
{
    private float _speedAttack;
    private GameObject _target;
    private Action _dead;

    public void Create(GameObject target, Action dead)
    {
        _dead = dead;
        _target = target;
    }

    private void Attack(GameObject target)
    {
        if (!target.tag.Equals(Constant.TAG_TANK_S)) return;
        var tower = target.transform.GetComponent<Tank>();
        if (tower != null)
            tower.Damage(Strength);
        Damage(Health / Protection);
    }

    public void Damage(float damage)
    {
        Health -= damage*Protection;
        if (Health <= 0)
        {
            _dead();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals(Constant.TAG_TANK_S)) return;
        var tank = collision.transform.GetComponent<Tank>();
        if (tank != null)
            tank.Damage(Strength);
        Destroy(gameObject);
    }

    void Update()
    {
        if(_target==null) return;
        if (_speedAttack >= 0)
            _speedAttack -= Time.deltaTime;
        if (Vector3.Distance(transform.position, _target.transform.localPosition) > 1)
        {
            var direction = (_target.transform.localPosition - transform.position).normalized;
            transform.Translate(direction*Speed*Time.deltaTime);
        }
        if (_speedAttack < 0 &&
            Vector3.Distance(transform.position, _target.transform.localPosition) < 2)
        {
            Attack(_target);
        }
    }
}