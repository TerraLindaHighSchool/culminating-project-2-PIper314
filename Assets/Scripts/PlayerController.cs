using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    public TextMeshProUGUI timerText;

    private string laneChange = "n";
    private string jump = "n";
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
       
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerText.text = "Timer: " + minutes + ":" + seconds;

        if (Input.GetKey("d") && (laneChange == "n") && (transform.position.z > -.9) && (jump == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, -1);
            laneChange = "y";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("a") && (laneChange == "n") && (transform.position.z < .5) && (jump =="n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 1);
            laneChange = "y";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("space") && (jump == "n") && (laneChange == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 1f, 0);
            StartCoroutine(stopJump());
            jump = "y";
        }
    }

    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(2, -1f, 0);
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
        jump = "n";
    }
    IEnumerator stopLaneChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
        laneChange = "n";
       // Debug.Log(GetComponent<Transform>().position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "obstacle")
        {
            Debug.Log("Game Over");
            gameController.GameOver();
            Destroy(gameObject);
        }
    }
}
