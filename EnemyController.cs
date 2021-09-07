using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioClip deathFx;

    GameObject player;
    Animator anim;
    AudioSource enemyFx;
    bool isAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();    
        enemyFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && isAlive) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit")) {
            anim.SetTrigger("Dead");
            isAlive = false;
            enemyFx.PlayOneShot(deathFx);
            Destroy(gameObject, 0.3f);
        }
    }

}
