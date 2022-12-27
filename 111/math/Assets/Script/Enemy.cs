using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public float moveSpeed = 0.01f;
    public float health = 10.0f;
    public float bulletDamage = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //적을 플레이어 위치로 이동
        transform.position = Vector3.MoveTowards(gameObject.transform.position, GameObject.Find("Player").transform.position, moveSpeed);  
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //총알에 닿았을때
        if (other.tag == "Bullet") {
            //Play Particle
            //ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            //instance.Play();
            //Destroy(instance.gameObject, instance.main.duration);
 
            //Take Damage
            health -= bulletDamage;
            if (health <= 0) {
                //Set Active off
                Match.enemyNum -= 1;
                Destroy(gameObject);
            }
        } else if(other.tag == "Player") {
            player.health -= 1;
            Destroy(gameObject);
        }
    }
}
