using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
	}
}
