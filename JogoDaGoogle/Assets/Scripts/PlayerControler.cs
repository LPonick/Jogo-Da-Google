using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarDoPlayer : MonoBehaviour
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

    private Rigidbody2D _Rig;
    void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movimentacao();
        DetectaChao();
    }
    private void Awake()
    {
        
    }

    private void DetectaChao()
    {
        //Um ponto para saber se o player esta no ar ou não.
        _PodePular = Physics2D.OverlapPoint(_PontoDoChao.position,_LayerChao);
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
    
}
