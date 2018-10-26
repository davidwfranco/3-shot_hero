using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float moveDir;
	private float movementSpeed;
	private Rigidbody2D rb2d;
	public GameObject bulletPrefab;
	private bool jumping;
	private int jumpCount;

	// Use this for initialization
	void Start () {
		moveDir = 0;
		movementSpeed = 6f;
		rb2d = this.GetComponent<Rigidbody2D>();
		jumping = false;
		jumpCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		moveDir = Input.GetAxisRaw("Horizontal");

		if(moveDir != 0) {
			transform.Translate(Vector2.right * moveDir * movementSpeed * Time.deltaTime);
		}

		if(Input.GetKeyDown("space")) {
			if (!jumping) {
				rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
				jumpCount ++;
				if (jumpCount == 2) {
					jumping = true;
					jumpCount = 0;
				}
			}
			this.Shoot();
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Floor")) {
			jumping = false;
		}
	}

	private void Shoot() {
		Instantiate(bulletPrefab, new Vector2(this.transform.position.x + (transform.localScale.x/10 * 7), this.transform.position.y), Quaternion.identity);
	}
}
