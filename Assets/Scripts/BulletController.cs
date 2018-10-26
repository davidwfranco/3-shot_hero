using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	private float bulletSpeed;
	private GameController gControll;
	// Use this for initialization
	void Start () {
		gControll = GameController.instance;
		bulletSpeed = gControll.initBulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

		if (transform.position.x > gControll.targetCamtWidth.x) {
			Destroy(gameObject);
		}
	}
}