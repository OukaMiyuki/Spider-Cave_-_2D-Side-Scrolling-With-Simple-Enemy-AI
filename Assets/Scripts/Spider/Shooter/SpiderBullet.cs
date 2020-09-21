using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            //Destroy(collision.gameObject);
            PlayerMoveController.instance.isPlayerAlive = false;
            PlayerMoveController.instance.RunningAnimation();
            Destroy(gameObject);
        }

        if (collision.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
