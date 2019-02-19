using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingLeft = true;
    private int randFacing;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10f);
        rb2d = GetComponent<Rigidbody2D>();
        randFacing = Random.Range(0, 2);
        if (randFacing == 1) {
            facingLeft = false;
        }

        if (!facingLeft)
        {
            Transform t = rb2d.transform;
            t.localScale = new Vector3((t.localScale.x * -1f), t.localScale.y, t.localScale.z);
            rb2d.transform.localScale = t.localScale;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        float speed = 2.0f;
        if (facingLeft) {
            speed *= -1;
        }
        Vector2 movement = Vector2.zero;
        movement.x = (transform.right * Time.deltaTime * speed).x;
        movement = movement + (Vector2)(transform.position);

        rb2d.MovePosition(movement);
        //rb2d.velocity = new Vector2((vel.x * Time.deltaTime), vel.y);
        //rb2d.AddForce(new Vector2(rb2d.velocity.x * Time.deltaTime, rb2d.velocity.y));
    }
}
