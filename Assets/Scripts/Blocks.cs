using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Sprite brokenImage;
    public float health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude>health)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = brokenImage;
            if (collision.relativeVelocity.magnitude > health)
            {
                Destroy(gameObject);
            }
        }
    }
}
