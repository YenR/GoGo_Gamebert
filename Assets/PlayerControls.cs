using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 jumpForce = new Vector2(0f, 10f);

    public float groundLevel;

    public static PlayerControls instance;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    float lastPressed = 0;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && lastPressed != Time.time)
        {
            lastPressed = Time.time;
            Jump();
        }
        if ((jumping || flying) && this.gameObject.transform.position.y <= groundLevel)
        {
            jumping = false;
            flying = false;

            gamebert.SetBool("fly", false);
            gamebert.SetBool("jump", false);
        }
    }

    public Animator gamebert;
    private bool jumping = false, flying = false;

    public void Jump()
    {
        if (this.gameObject.transform.position.y <= groundLevel && !gameOver)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            jump.PlayOneShot(jump.clip);
            gamebert.SetBool("jump", true);
            jumping = true;
        }
    }

    public void init_gameOver()
    {
        globalVars.lootboxes_left++;
        StartCoroutine(showGameOverStuff(3));

        bgm.Stop();
        gamovr.Play();

        gameOver = true;
        scrollerMaster.instance.updateScrollSpeed(0f);
        gameOverAnimator.SetTrigger("gameOver");
        gamebert.SetTrigger("dead");
    }

    public Animator gameOverAnimator;

    public GameObject gameOverStuff;

    IEnumerator showGameOverStuff(int secs)
    {
        yield return new WaitForSeconds(secs);
        gameOverStuff.gameObject.SetActive(true);
    }

    public AudioSource jump, fly, pickup, gamovr,bgm;
}

