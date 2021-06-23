using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarInimigo : MonoBehaviour
{
    public float _Velocidade;
    public bool _Slime = false;

    private int _Moviment = -1;
    private Rigidbody2D _Rig;
    private float _z;

    void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _Rig.velocity = new Vector2(_Velocidade * _Moviment, _Rig.velocity.y);
        if (_Slime)
        {
            _z = _z + Time.deltaTime * 500;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, _z);
        }
    }
}
