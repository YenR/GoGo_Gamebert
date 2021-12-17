using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollerMaster : MonoBehaviour
{
    public static scrollerMaster instance;

    public endlessScroll[] scrollers;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScrollSpeed(float newSpeed)
    {
        foreach( endlessScroll es in scrollers )
        {
            es.scrollSpeed = newSpeed;
            es.rb.velocity = new Vector2(-newSpeed, 0);
        }
    }

}
