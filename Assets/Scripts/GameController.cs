using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    public bool isGameActive;

    private float startTime;
    public Transform tileObj;
    public Transform crateObj;
    public Transform rockObj;
    //public Transform barrelObj;

    private Vector3 nextCrateObj;
    private Vector3 nextTileSpawn;
    private Vector3 nextRockSpawn;
    //private Vector3 nextBarrelSpawn;
    private int randomZ;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
      
        nextTileSpawn.x = 21;
        StartCoroutine(spawnTile());
    }

    /*public void UpdateTimer()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }*/

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        startTime = 0;

        titleScreen.gameObject.SetActive(false);
    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        nextCrateObj = nextTileSpawn;
        randomZ = Random.Range(-1, 2);

        nextCrateObj.y = .2f; 
        nextCrateObj.z = randomZ;
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        Instantiate(crateObj, nextCrateObj, crateObj.rotation);

        if(randomZ == 0)
        {
            randomZ = 1;
        }
        else
            if(randomZ == 1)
            {
                randomZ = -1;
            }
            else
            {
                randomZ = 0;
            }

        nextTileSpawn.x += 3;
        //randomZ = Random.Range(-1, 2);
        nextRockSpawn.x = nextTileSpawn.x;
        nextRockSpawn.y = .176f;
        nextRockSpawn.z = randomZ;
        Instantiate(rockObj, nextRockSpawn, rockObj.rotation);

        StartCoroutine(spawnTile());
    }


}
