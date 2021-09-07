using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    SpriteRenderer sprite;
    AudioSource shootFx;

    public GameObject arrow;
    public Transform arrowSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shootFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    void Aim() 
    {
        // Pegar posição do mouse e vetorizar com a posição do personagem
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        
        // Rodar sprite de acordo com posição do mouse
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
        
        
        /* Outra opção para linha anterior
        if (mousePos.x < screenPoint.x) {
            sprite.flipY = true;
        else 
            sprite.flipY = false;*/
    }

    void Shoot() 
    {
        // Atirar a flecha
        if (Input.GetButtonDown("Fire1")) 
        {
            Instantiate(arrow, arrowSpawn.position, transform.rotation);
            shootFx.Play();
        }

    }
}
