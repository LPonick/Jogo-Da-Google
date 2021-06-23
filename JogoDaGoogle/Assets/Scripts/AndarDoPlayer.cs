using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public bool _PodePular;
    public float _JumpForce;

    [SerializeField]
    private float _Velocidade;
    [SerializeField]
    private Transform _PontoDoChao;
    [SerializeField]
    private LayerMask _LayerChao;
    [SerializeField]
    private LayerMask _LayerInimigo;

    private Rigidbody2D _Rig;

    public int _Pontos;
    void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movimentacao();
        DetectaChao();
    }
    private void DetectaChao()
    {
        //Um ponto para saber se o player esta no ar ou não.
        _PodePular = Physics2D.OverlapPoint(_PontoDoChao.position, _LayerChao);

        //detecta pontos
        RaycastHit2D bateuDown = Physics2D.Raycast(gameObject.transform.position, -transform.up, 100, _LayerInimigo);
        RaycastHit2D bateuUp = Physics2D.Raycast(gameObject.transform.position, transform.up, 100, _LayerInimigo);

        if (bateuDown)
        {
            //hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            if (bateuDown.collider.GetComponent<InimigoControler>())
            {
                var Inimigo = bateuDown.transform.GetComponent<InimigoControler>();
                if (!Inimigo._PontoContado)
                    _Pontos++;

                Inimigo._PontoContado = true;
            }
            
        }
        if(bateuUp)
        {
            if (bateuUp.collider.GetComponent<InimigoControler>())
            {
                var Inimigo = bateuUp.transform.GetComponent<InimigoControler>();
                if (!Inimigo._PontoContado)
                    _Pontos++;

                Inimigo._PontoContado = true;
            }
        }
    }

    private void Movimentacao()
    {
        float Movimentacao = Input.GetAxis("Horizontal");
        _Rig.velocity = new Vector2(Movimentacao * _Velocidade, _Rig.velocity.y);

        if (Input.GetButtonDown("Jump") && _PodePular)
        {
            _Rig.AddForce(new Vector2(0f, _JumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
            gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
            gameObject.SetActive(false);

    }

}
