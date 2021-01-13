using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private GameController gameController;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        startButton.onClick.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Play()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameController.StartGame();
    }
}
