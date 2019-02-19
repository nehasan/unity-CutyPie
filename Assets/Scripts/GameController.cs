using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject playerPrefab;
    public Transform playerSpawn;
    public int playerLife;
    public GameObject playerLifeObject;
    public GameObject lifeSlot;
    private bool reSpawnPlayer;
    public int score;
    public GameObject scoreObject;
    public GameObject scoreSLot1;
    public GameObject scoreSLot2;

	// Use this for initialization
	void Start () {
        playerLife = 2;
        score = 0;
        reSpawnPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerLife >= 0 && reSpawnPlayer) {
            reSpawnPlayer = false;
            Invoke("ReSpawnPlayer", 3.0f);
        }
        if (playerLife < 0) {
            Invoke("GoHome", 3.0f);
        }
        ControlPlayerLife();
        ControlScore();
	}

    void ReSpawnPlayer() {
        Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
    }

    void ControlPlayerLife() {
        if (playerLife >= 0) {
            int life = playerLife / 2; //as the player has two capsule colliders and it doubles the collision event
            lifeSlot.GetComponent<SpriteRenderer>().sprite =
                playerLifeObject.GetComponent<Transform>().GetChild(playerLife).GetComponent<SpriteRenderer>().sprite;
            //playerLifeObject.GetComponent<Transform>().GetChild(playerLife + 1).gameObject.SetActive(false);
            //playerLifeObject.GetComponent<Transform>().GetChild(playerLife).gameObject.SetActive(true);
        }
    }

    void ControlScore() {
        //Debug.Log(score);
        int s = score / 2; // as the player has 2 capsule colliders and it doubles the collision event
        int[] digit = new int[2];
        int n = 1;
        if (s < 10)
        {
            digit[1] = s; digit[0] = 0;
        }
        else {
            while (s > 0)
            {
                digit[n] = s % 10;
                s /= 10;
                n--;
            }
        }
        scoreSLot2.GetComponent<SpriteRenderer>().sprite = scoreObject.transform.GetChild(digit[1]).GetComponent<SpriteRenderer>().sprite;
        scoreSLot1.GetComponent<SpriteRenderer>().sprite = scoreObject.transform.GetChild(digit[0]).GetComponent<SpriteRenderer>().sprite;
    }

    public void SetReSpawnPlayer(bool flag) {
        reSpawnPlayer = flag;
    }

    public void GoHome() {
        SceneManager.LoadScene("MenuScene");
    }
}
