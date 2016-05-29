using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private const int width = 40;
    private const int height = 25;
    [SerializeField] private float _timeCreate;
    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private int _maxMonsters;

    private float _time;
    private int countMonster;

    void Start()
    { }

    void Update()
    {
        if (Main.inctance.GetGameState(Main.GameState.GameOver)) RefreshMonsters();
        if (Main.inctance.GetGameState(Main.GameState.Paused)) return;
        _time -= Time.deltaTime;
        if (_time <= 0.0f && countMonster < _maxMonsters)
        {
            var tank = GameObject.Find("Tank(Clone)");
            CreateMonster(tank);
            _time = _timeCreate;
        }
    }

    private void CreateMonster(GameObject target)
    {
        var monster = Instantiate(_monsters[Random.Range(0, 3)], new Vector3(), Quaternion.identity) as GameObject;
        if (monster != null)
        {
            monster.transform.parent = transform;
            monster.transform.localPosition = new Vector3(Random.Range(-width, width), Random.Range(-height, height));
            monster.GetComponent<Monster>().Create(target, DecrementMonsters);
            countMonster++;
        }
    }

    public void DecrementMonsters()
    {
        countMonster--;
    }

    public void RefreshMonsters()
    {
        _time = 0;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
            Main.inctance.SetGameState(Main.GameState.Paused);
        }
    }
}