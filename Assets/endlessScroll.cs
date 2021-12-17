using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessScroll : MonoBehaviour
{

    //public BoxCollider2D boxColl;
    public Rigidbody2D rb;

    public float width = 30;
    public float scrollSpeed = 2f;

    private Vector2 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-scrollSpeed, 0);
        resetPosition = new Vector2(width * 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
