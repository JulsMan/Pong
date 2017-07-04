using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 10;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.rigidBody.velocity = Vector2.right * speed;
		
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        // Left paddle or rightpaddle
        if((col.gameObject.name == "paddle-left") || (col.gameObject.name == "paddle-right") )
        {
            handlePaddleHit(col);
        }


        if ((col.gameObject.name == "wall-left") || (col.gameObject.name == "wall-right"))
        {
            // 
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.WallBounce);

            // TODO - update score
        }


        if ((col.gameObject.name == "wall-top") || (col.gameObject.name == "wall-bottom"))
        {
            // 
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.WallBounce);
        }
    }

    private void handlePaddleHit(Collision2D col)
    {
        float y = ballHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "paddle-left")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "paddle-right")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.PaddleBounce);
    }

    private float ballHitPaddleWhere(Vector3 ball, Vector3 paddle, float y)
    {
        return (ball.y - paddle.y) / y;
    }
}
