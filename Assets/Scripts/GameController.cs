using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public Camera cam;
    private bool gameOver;
    [Range(1.01f, 4.0f)]
    public float initPlayerSpeed;
    [Range(5.01f, 10.0f)]
    public float initBulletSpeed;
    public Vector2 upperCorner;
    public Vector2 targetCamtWidth;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }

        if (cam == null) {
            cam = Camera.main;
        }

        upperCorner = new Vector2(Screen.width, Screen.height);
        targetCamtWidth = GameController.instance.cam.ScreenToWorldPoint(upperCorner);
    }

    public bool getGameOver() {
        return gameOver;
    }

    public void setGameOver(bool gameOverToSet) {
        this.gameOver = gameOverToSet;
    }
}
