using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ParticleSystem effect;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Criar flecha e destruir na colisão
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
