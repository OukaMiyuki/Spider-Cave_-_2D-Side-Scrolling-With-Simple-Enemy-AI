using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour {

    [SerializeField] GameObject bullet;

    void Start() {
        StartCoroutine(AttackThePlayer());
    }

    IEnumerator AttackThePlayer() {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(AttackThePlayer());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            //Destroy(collision.gameObject);
            PlayerMoveController.instance.isPlayerAlive = false;
            PlayerMoveController.instance.RunningAnimation();
        }
    }
}
