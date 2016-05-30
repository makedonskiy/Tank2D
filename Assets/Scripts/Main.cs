using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main inctance;

    public const int width = 40;
    public const int height = 20;

    [SerializeField]
    private Button _playBtn;
    [SerializeField]
    private Button _exitBtn;

    public enum GameState
    {
        Playing, Paused, GameOver
    }

    GameState currentGameState = GameState.Paused;

    void Start()
    {
        inctance = this;
        _playBtn.onClick.AddListener(Play);
        _exitBtn.onClick.AddListener(Exit);
    }

    private void Play()
    {
        currentGameState = GameState.Playing;
        var tank = GameObject.Find("Tank(Clone)");
        if (tank == null)
        {
            tank = Resources.Load("Prefab/Tank") as GameObject;
            if (tank != null)
            {
                SetActiveButton(false);
                Instantiate(tank);
            }
        }
        else
        {
            SetActiveButton(false);
            currentGameState = GameState.Playing;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            currentGameState = GameState.Paused;
            SetActiveButton(true);
        }
    }

    private void Exit()
    {
        Application.Quit();
    }

    public void SetGameState(GameState state)
    {
        currentGameState = state;
    }

    public bool GetGameState(GameState state)
    {
        return currentGameState == state;
    }

    public void SetActiveButton(bool state)
    {
        _playBtn.gameObject.SetActive(state);
        _exitBtn.gameObject.SetActive(state);
    }
}