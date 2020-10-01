using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : MonoBehaviour {

    public static RunAnimation instance;

    [Header("Animation Component")]
    [SerializeField] private Animator animator;

    //[Header("Components")]
    //[SerializeField] private Rigidbody2D rb;

    bool fallGround = false;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "FallGround") {
            print("Falling");
            fallGround = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "FallGround") {
            fallGround = false;
        }
    }

    public void RunningAnimation() {
        if (!PlayerWin.instance.GetWin()) {
            if (PlayerMoveController.instance.rb.velocity.y > 0.05f) {
                animator.Play("Miku_Jump");
            }
            else if (PlayerMoveController.instance.rb.velocity.y < -0.1f  && !fallGround) {
                animator.Play("Miku_Fall");
                if (PlayerMoveController.instance.onGround) {
                    animator.Play("Miku_Fall_Ground");
                }
            }

            if ((PlayerMoveController.instance.onGround && !Input.GetButtonDown("Jump")) && PlayerDeath.instance.GetDieOrAlive()) {
                if (PlayerMoveController.instance.direction.x == 1 || PlayerMoveController.instance.direction.x == -1) {
                    animator.Play("Miku_Run");
                }
                else if (PlayerMoveController.instance.direction.x == Mathf.Epsilon) {
                    animator.Play("Miku_Idle");
                }
            }

            if (!PlayerDeath.instance.GetDieOrAlive()) {
                PlayerMoveController.instance.rb.gravityScale = 10;
                animator.Play("Miku_Die");
            }
        }
        if (PlayerWin.instance.GetWin() && PlayerDeath.instance.GetDieOrAlive()) {
            animator.Play("Miku_Dance");
            PlayerMoveController.instance.rb.gravityScale = 10;
            PlayerMoveController.instance.rb.drag = 0;
        }
    }
}
