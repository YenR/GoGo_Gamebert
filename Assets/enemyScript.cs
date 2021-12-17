using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Animator gameOverAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        //Time.timeScale = 0;
        PlayerControls.instance.gameOver = true;
        scrollerMaster.instance.updateScrollSpeed(0f);
        gameOverAnimator.SetTrigger("gameOver");
    }
}
