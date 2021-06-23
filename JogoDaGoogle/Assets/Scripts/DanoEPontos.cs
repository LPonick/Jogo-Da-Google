//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DanoEPontos : MonoBehaviour
//{
//    //Script para deteccao de inimigos e contabilizador de pontos 

//    public int _Pontos;
//    bool _Bateu = false;
//    [SerializeField]
//    LayerMask _LayerInimigo;
//    [SerializeField]
//    GameCotrole _controDePontos;
    
//    void Start()
//    {
        
//    }


//    void Update()
//    {
//        morteDoPlayer();
//        linhaDePontos();
//    }

//    private void linhaDePontos()
//    {
//        RaycastHit2D Pontos =Physics2D.Raycast(transform.position, -transform.up,100,_LayerInimigo);

//        if(Pontos)
//        {
//            _Pontos++;
//        }
//    }

//    private void morteDoPlayer()
//    {
//        //Metodo responsavel pela detecao se o player bateu de cara em um inimigos 
//        if(_Bateu)
//        {
//            gameObject.SetActive(false);
//        }
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        //Deteccao do player com inimigos
//        if(collision.gameObject.tag == "Inimigo")
//        {
//            _Bateu = true;
//        }
//    }
//}
