using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(3, 0, -1);
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 1);
            StartCoroutine(stopLaneChange());
        }
    }

    IEnumerator stopLaneChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
        Debug.Log(GetComponent<Transform>().position);
    }
}
