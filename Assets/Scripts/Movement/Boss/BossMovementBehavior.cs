using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon Script
//Date: 07/22/2022
public class BossMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rb;
    private Vector3 _direction;
    public Vector3 Direction { set => _direction = value; }
    public float Speed { set => _speed = value; }


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _direction * _speed;
    }
}
