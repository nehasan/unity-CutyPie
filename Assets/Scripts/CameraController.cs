using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 camOffset;

	// Use this for initialization
	void Start () {
        camOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void LateUpdate() {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else {
            transform.position = player.transform.position + camOffset;
        }
    }
}
