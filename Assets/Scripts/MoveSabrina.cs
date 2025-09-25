using UnityEngine;


public class MoveSabrina : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 8f;    
    public Transform checagemChao;
    public float raioChao = 0.2f;
    public LayerMask camadaChao;
    private float horizontal;
    private Rigidbody2D rb;
    private bool estaNoChao;
    public bool PodeMexer = true;
    private bool isGrounded;

    [Header("Som de Movimento")]
    public AudioSource somMovimento;  // AudioSource
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Entrada de movimento lateral
        horizontal = Input.GetAxisRaw("Horizontal");



        // Checar se está no chão
        estaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChao, camadaChao);



        // Movimento
        rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);


        // Pulo
        if (Input.GetButtonDown("Jump") && estaNoChao) // botão (barra de espaço)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
        // Animações
        if (horizontal != 0)
        {
            animator.Play("walk");
        }
        else
        {
            animator.Play("idle");
        }
        if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontal > 0)
        {

            GetComponent<SpriteRenderer>().flipX = false;
        }
        // Debug
        print($"Horizontal: {horizontal} | No chão: {estaNoChao}");
    }

    
       private void OnCollisionEnter2D(Collision2D collision)
       {
        if (collision.gameObject.CompareTag("Chao"))
        {
            isGrounded = true;
        }
       }
}