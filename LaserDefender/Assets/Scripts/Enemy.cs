using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Life")]
    [SerializeField] float health = 100;
    [SerializeField] GameObject explosionVFX;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1.5f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;

    [Header("Audio")]
    [SerializeField] AudioClip deathAudio;
    [SerializeField] [Range(0, 1)] float deathAudioVolume = 0.75f;
    [SerializeField] AudioClip shootAudio;
    [SerializeField] [Range(0, 1)] float shootAudioVolume = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
        
    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter<=0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    
    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootAudio, Camera.main.transform.position,shootAudioVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcesHit(damageDealer);
    }

    private void ProcesHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathAudio, Camera.main.transform.position, deathAudioVolume);
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
