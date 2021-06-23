using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float _VelocidadeDeSpawn;      
    [Space]
    public GameObject[] _Inimigos;
    [Space]
    [SerializeField]
    bool _TesteOn;

    private float _ProximoSpawn;
    private int _Range,_Tamanho,_Index;
    public enum Dificuldades
    {
        Dificuldade1,
        Dificaldade2,
        Dificuldade3,
        Dificuldade4,
        Dificuldade5
    };
    [Space]
    public Dificuldades _SelecionarDificuldade;
    private void Start()
    {
        if (_TesteOn)
            _Tamanho = 0;
        else
            _Tamanho = _Inimigos.Length;
    }
    void Update()
    {
        //_Range = _Tamanho;

        //ConfigDificuldade();
        //SpawnaInimigos();
    }

    private void SpawnaInimigos()
    {
        if (Time.time > _ProximoSpawn)
        {
            DarUmNumero(ref _Index);
            _ProximoSpawn = Time.time + _VelocidadeDeSpawn;
            Instantiate(_Inimigos[_Index], transform.position, _Inimigos[_Index].transform.rotation);
        }
    }

    public void DarUmNumero(ref int NumeroDado)
    {
        NumeroDado = Random.Range(0,_Range);
    }
    void ConfigDificuldade()
    {
        //Como a dificudade tem que ser...
        switch(_SelecionarDificuldade)
        {
            case Dificuldades.Dificuldade1:
                for(int X = 0; X >= _Inimigos.Length; X++)
                {
                    //GameObject InimigoT = _Inimigos[X].GetComponent<InimigoControler>();
                    //if (InimigoT._InimigoVoa)
                    //{
                    //    InimigoT._Velocidade = 44;
                    //}
                    //else
                    //{
                    //    InimigoT._Velocidade = 22;
                    //}
                }
                _VelocidadeDeSpawn = 1.5f;
                //dificuldade padrao "A mais facil"...
            break;
                case Dificuldades.Dificaldade2:


                break;

        }
    }
}
