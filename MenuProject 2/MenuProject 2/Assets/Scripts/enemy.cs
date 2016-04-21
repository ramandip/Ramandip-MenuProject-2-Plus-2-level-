using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public float moveForce = 100f;
    private Transform transform;
    private Rigidbody2D rigidBody2d;
    private Vector3 _horizenPosition;

    private float xspeed = 100;
    // Use this for initialization
    void Start () {
        transform = gameObject.GetComponent<Transform>();
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
       
        this._horizenPosition = this.transform.position;
        this._horizenPosition -= new Vector3(this.xspeed, 0);
    }
}
