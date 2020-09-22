using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            print("Mati");
            collision.GetComponent<PlayerMoveController>().isPlayerAlive = false;
            print(collision.GetComponent<PlayerMoveController>().isPlayerAlive);
            collision.GetComponent<PlayerMoveController>().RunningAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerMoveController>().isPlayerAlive = false;
            collision.gameObject.GetComponent<PlayerMoveController>().RunningAnimation();
        }
    }
}
