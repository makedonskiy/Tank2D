using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private float TimeDestroy = 5;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public void Create(GameObject gun)
    {
        transform.eulerAngles = gun.transform.eulerAngles;
        transform.localPosition = gun.transform.position;
        var speed = gun.transform.right.normalized*_speed*100;
        GetComponent<Rigidbody2D>().AddForce(speed);
    }

    void Update()
    {
        TimeDestroy -= Time.deltaTime;
        if (TimeDestroy <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals(Constant.TAG_MONSTER_S)) return;
        var monster = collision.transform.GetComponent<Monster>();
        if (monster != null)
            monster.Damage(_damage);
        Destroy(gameObject);
    }
}