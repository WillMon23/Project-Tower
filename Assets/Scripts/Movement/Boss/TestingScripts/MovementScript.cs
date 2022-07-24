using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 _velocity;
    private Vector3 _input;
    private Rigidbody _rb;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;


    public Vector3 Input { set => _input = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _velocity = _input  * _speed;
        _rb.velocity = _velocity;
    }
}
