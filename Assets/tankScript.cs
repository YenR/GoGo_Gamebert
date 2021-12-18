using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScript : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = new Vector2(0, -speed);
    }
}
