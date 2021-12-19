using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 jumpForce = new Vector2(0f, 10f);
    public Vector2 flyForce = new Vector2(0f, 15f);

    public float groundLevel;

    public static PlayerControls instance;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startTime = Time.time;
        updateBorger();
        updateBooks();
        updateChip();
        updateDrinks();
    }

    public void updateBorger()
    {
        borgT.SetText(globalVars.borgers.ToString());
        if (globalVars.borgers <= 0)
            borgB.interactable = false;
    }

    public void updateChip()
    {
        chipT.SetText(globalVars.chips.ToString());
        if (globalVars.chips <= 0)
            chipB.interactable = false;
    }

    public void updateBooks()
    {
        bookT.SetText(globalVars.books.ToString());
        if (globalVars.books <= 0)
            bookB.interactable = false;
    }

    public void updateDrinks()
    {
        drinkT.SetText(globalVars.drinks.ToString());
        if (globalVars.drinks <= 0)
            drinkB.interactable = false;
    }

    public void borgerPressed()
    {
        if(globalVars.borgers <= 0)
        {
            err.PlayOneShot(err.clip);
        }
        else
        {
            scrollerMaster.instance.reduceSpeed();
            globalVars.borgers--;
            updateBorger();
        }
    }

    public void chipPressed()
    {
        if (globalVars.chips <= 0)
        {
            err.PlayOneShot(err.clip);
        }
        else
        {
            scrollerMaster.instance.addSpeed();
            globalVars.chips--;
            updateChip();
        }
    }

    public void drinkPressed()
    {
        Debug.Log("drink pressed");
        if(globalVars.drinks <= 0 || !jumping)
        {
            err.PlayOneShot(err.clip);
        }
        else
        {
            rb.AddForce(flyForce, ForceMode2D.Impulse);
            fly.PlayOneShot(fly.clip);
            gamebert.SetBool("fly", true);
            flying = true;
            globalVars.drinks--;
            updateDrinks();
        }
    }

    float lastPressed = 0;
    // Update is called once per frame
    void Update()
    {
        if ((jumping || flying) && this.gameObject.transform.position.y < groundLevel && (lastPressed + 1f < Time.time))
        {
            Debug.Log("cancel jump"+ lastPressed+ ", "+  Time.time);

            jumping = false;
            flying = false;

            gamebert.SetBool("fly", false);
            gamebert.SetBool("jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && lastPressed != Time.time)
        {
            Jump();
        }
    }

    public Animator gamebert;
    private bool jumping = false, flying = false;

    public void Jump()
    {
        lastPressed = Time.time;
        if (this.gameObject.transform.position.y <= groundLevel && !gameOver)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            jump.PlayOneShot(jump.clip);
            gamebert.SetBool("jump", true);
            jumping = true;
        }
    }

    public TMP_Text scoreTxt;
    private float startTime = 0;

    public void init_gameOver()
    {
        if (gameOver)
            return;

        borgB.gameObject.SetActive(false);
        chipB.gameObject.SetActive(false);
        bookB.gameObject.SetActive(false);
        drinkB.gameObject.SetActive(false);

        globalVars.lootboxes_left++;
        StartCoroutine(showGameOverStuff(3));

        scoreTxt.SetText((Time.time - startTime).ToString("F2"));

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

    public AudioSource jump, fly, pickup, gamovr,bgm, err;

    public Button borgB, chipB, bookB, drinkB;
    public TMP_Text borgT, chipT, bookT, drinkT;
}

