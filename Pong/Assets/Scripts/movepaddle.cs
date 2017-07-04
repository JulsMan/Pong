using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movepaddle : MonoBehaviour {

    public float speed = 10;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        float vPress = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vPress) * speed;
    }

   
}
