using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcesHit(collision, damageDealer);
    }

    private void ProcesHit(Collider2D collision, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        Destroy(collision.gameObject);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
