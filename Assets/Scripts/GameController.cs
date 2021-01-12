using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform tileObj;
    public Transform crateObj;
    public Transform rockObj;
    public Transform barrelObj;

    private Vector3 nextCrateObj;
    private Vector3 nextTileSpawn;
    private Vector3 nextRockSpawn;
    private Vector3 nextBarrelSpawn;
    private int randomZ;
    
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

        nextBarrelSpawn.x = nextTileSpawn.x - 1;
        nextBarrelSpawn.y = .179f;
        nextBarrelSpawn.z = randomZ;
        Instantiate(barrelObj, nextBarrelSpawn, barrelObj.rotation);
        StartCoroutine(spawnTile());
    }


}
