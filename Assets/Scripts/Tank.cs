using System;
using UnityEngine;

public class Tank : LiveObject
{
    [SerializeField] private GameObject _tower;

    void Start()
    { }

    void Update()
    {
        if (Main.inctance.GetGameState(Main.GameState.Paused)) return;
        MovedTank(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        MovedTower(Input.GetAxis("Tower"));
    }

    internal void Damage(int damage)
    {
        Health -= damage * Protection;
        if (Health <= 0)
        {
            Main.inctance.SetGameState(Main.GameState.GameOver);
            Main.inctance.SetActiveButton(true);
            Destroy(gameObject);
        }
    }

    private void MovedTank(float moved, float angle)
    {
        var speed = moved*Speed*Time.deltaTime;
        transform.localPosition += new Vector3(speed*(float) Math.Cos(Mathf.Deg2Rad*transform.eulerAngles.z),
            speed*(float) Math.Sin(Mathf.Deg2Rad*transform.eulerAngles.z));
        transform.eulerAngles += new Vector3(0, 0, angle*2);
    }

    private void MovedTower(float angle)
    {
        _tower.transform.eulerAngles += new Vector3(0, 0, angle);
    }
}