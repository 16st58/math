using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public float speed = 5.0f;
    public float lifeTime = 10.0f;
 
    private Rigidbody2D rigid;
 
 
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        rigid.velocity = transform.up * speed;
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Play Particle
            //ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            //instance.Play();
            //Destroy(instance.gameObject, instance.main.duration);
 
            //Take Damage
 
            //Set Active off
            Destroy(gameObject);
        }
    }
}
