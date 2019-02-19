using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour {

    public GameObject coinSpawns;
    public GameObject coinPrefab;
    public float waitSec = 5f;
    private int maxNumCoins;
    public int totalGenCoins;

	// Use this for initialization
	void Start () {
        maxNumCoins = 3;
        totalGenCoins = 0;
        SpawnCoin();
        totalGenCoins++;
        InvokeRepeating("SpawnCoin", waitSec, waitSec);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnCoin() {
        if ((totalGenCoins >= 0) && (totalGenCoins < maxNumCoins)) {
            int randSpawn = Random.Range(0, 10);
            GameObject spawn = coinSpawns.transform.GetChild(randSpawn).gameObject;
            Instantiate(coinPrefab, spawn.transform.position, spawn.transform.rotation);
            totalGenCoins++;
        }
    }
}
