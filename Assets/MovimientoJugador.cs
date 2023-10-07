using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{   private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;

    public float velocidadDeMovimiento;
    public float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    

    [Header("Salto")]

    public float fuerzasDeSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;
    private bool salto = false;

    [Header("Animacion")]

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        if(Input.GetButtonDown("Jump")){
            salto= true;
        }        
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
    }

    void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);  

        salto= false;
    }

    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if(mover > 0 && !mirandoDerecha){
            Girar();
        }
        else if (mover < 0 && mirandoDerecha){
            Girar();
        }

        if (enSuelo && saltar){
           enSuelo = false;
           rb2D.AddForce(new Vector2(0f,fuerzasDeSalto));
        }
    }

private void Girar(){
    mirandoDerecha= !mirandoDerecha;
    Vector3 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale= escala;

}

private void OnDrawGizmos(){
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
}


}
