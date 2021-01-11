using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.x = 21;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        nextTileSpawn.x += 3;
        StartCoroutine(spawnTile());
    }


}
