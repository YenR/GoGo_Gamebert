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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.gameObject.transform.position.y <= groundLevel && !gameOver)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
}
