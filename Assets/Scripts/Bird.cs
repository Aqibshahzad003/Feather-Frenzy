using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool hasExploded = false;
    private ParticleSystem ParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        ParticleEffect = GetComponentInChildren<ParticleSystem>();  
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded && (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Blocks"))
        {
            StartCoroutine(DestroyBird());
        }
    }
    private IEnumerator DestroyBird()
    {
        hasExploded = true;
        yield return new WaitForSeconds(2f); 

        // Hide the bird's sprite
        ParticleEffect.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(1f); 
        // Destroy the game object
        Destroy(gameObject);
    }
}
