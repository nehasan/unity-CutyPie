using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
    public GameObject enemySpawns;
    public GameObject[] enemies = new GameObject[3];
    private GameObject enemy;
    public float waitSec = 5f;

	// Use this for initialization
	void Start () {
        //StartCoroutine(LateCall());
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", waitSec, waitSec);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(waitSec);

        int randEnemy = Random.Range(0, 2);
        int randSpawnPlace = Random.Range(0, 6);
        Debug.Log(randSpawnPlace);
        GameObject spawnPlace = enemySpawnPlaces.transform.GetChild(randSpawnPlace).gameObject;
        Instantiate(enemies[randEnemy], spawnPlace.transform.position, spawnPlace.transform.rotation);
    }
    */

    void SpawnEnemy() {
        int randEnemy = Random.Range(0, 3);
        int randSpawn = Random.Range(0, 6);
        //Debug.Log(randSpawnPlace);
        GameObject spawn = enemySpawns.transform.GetChild(randSpawn).gameObject;
        enemy = enemies[randEnemy];
        Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
    }

}
