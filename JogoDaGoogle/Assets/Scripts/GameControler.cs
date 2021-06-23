using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    LayerMask _Inimigo;
    [SerializeField]
    GameObject _Player;
    [SerializeField]
    GameObject _CanvasGameOver;
    [SerializeField]
    TextMeshProUGUI _QuantidadePontosIU;
    RaycastHit2D Bateu;
    [SerializeField]
    PlayerControler _PontosDoPlayer;

    int _QuantidadeDePontos;

    void Start()
    {
        
    }

    void Update()
    {
        AparecerGameOver();
        ConvertoDePontos();
    }

    private void ConvertoDePontos()
    {
        _QuantidadeDePontos = _PontosDoPlayer._Pontos;
        _QuantidadePontosIU.text = _QuantidadeDePontos.ToString();
    }

    public void ReiniciaCena()
    {
        //Reloudar a cena atual.
        var Cena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(Cena.name);
    }
    void AparecerGameOver()
    {
        //se o objeto do player estiver desativado
        if(!_Player.activeSelf)
        {
            //show game over
            _CanvasGameOver.SetActive(true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(Bateu)
        Gizmos.DrawLine(_Player.transform.position,Bateu.point);
    }
}
