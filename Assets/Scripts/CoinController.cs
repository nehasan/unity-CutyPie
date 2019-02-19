using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("HELLO");
        if(other.gameObject.CompareTag("Player")){
            gameController.GetComponent<CoinsController>().totalGenCoins--;
            Destroy(gameObject);
            gameController.GetComponent<GameController>().score++;
        }
    }
}
