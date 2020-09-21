using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {

    [SerializeField] private float forceY = 300f;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start() {
        StartCoroutine(AttackThePayer());
    }

    IEnumerator AttackThePayer() {
        yield return new WaitForSeconds(Random.Range(2, 7));

        forceY = Random.Range(350f, 600f);

        rb.AddForce(new Vector2(0, forceY));
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(.7f);
        StartCoroutine(AttackThePayer());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            animator.SetBool("Attack", false);
        }

        if (collision.tag == "Player") {
            PlayerMoveController.instance.isPlayerAlive = false;
            PlayerMoveController.instance.RunningAnimation();
            //Destroy(collision.gameObject);
        }
    }
}
