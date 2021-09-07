using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
        //anim.SetBool("isMoving", (Mathf.Abs(moveInput.x) != 0 || Mathf.Abs(moveInput.y) != 0));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        // Morrer quando encostar em inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.5f);
        }
        
    }
    private void Move(){
        // Movimentação do jogador
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("isMoving", (moveInput.x != 0 || moveInput.y != 0));
    }
}
