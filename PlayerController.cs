using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    Animator anim;
    public float dashDist = 0.5f;
    public float dashSpeed;
    float lastDash;
    private Coroutine dashing;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Running();
        Dashing();
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("isMoving", (moveInput.x != 0 || moveInput.y != 0));
        
        //anim.SetBool("isMoving", (Mathf.Abs(moveInput.x) != 0 || Mathf.Abs(moveInput.y) != 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.5f);
        }
        
    }

    // Função de movimentação para correr/andar
    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = 5f;
        } else {
            moveSpeed = 3f;
        }
    }

    // Função de movimentação para dar um dash
    private void Dashing() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashing == null) {
            dashing = StartCoroutine(stopDash());
        }
    }
  
    // Para limitar velocidade durante o dash e impedir que dê um dash no meio de outro
    public IEnumerator stopDash() 
    {
        var rigidbody = GetComponent<Rigidbody2D>();

        for (float timer = 0 ; timer < dashDist ; timer += Time.deltaTime)
        {
            transform.Translate(moveInput * Time.deltaTime * dashSpeed);

            yield return new WaitForEndOfFrame();
        }
        dashing = null;
    }
}
