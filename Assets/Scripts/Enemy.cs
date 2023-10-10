using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    private ParticleSystem particleEffect;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        particleEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {

            StartCoroutine(DestroyEnemy());
        }
    }
    private IEnumerator DestroyEnemy()
    {
        // Hide the bird's sprite
        particleEffect.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(1f);
        // Destroy the game object
        manager.EnemyDestroyed();

        Destroy(gameObject);
    }
}
