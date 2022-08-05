using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    //The speed that the player moves
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _rotateSpeed;
    //The rigidbody of the player
    private Rigidbody _rigidbody;

    private Vector3 _movePosition;
    private Quaternion _targetRotation;
    private float _rotationTime;
    private Quaternion _previousRotation;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        move = move.normalized * Time.fixedDeltaTime * _moveSpeed;
        _rigidbody.velocity = move * 50;

        //if (move != Vector3.zero)
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.fixedDeltaTime * _rotateSpeed);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //If the cast is true an the mouse is on the screen
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Move position is set to the position of the cursor
            _movePosition = hit.point;
        }

        //Set the direction to look and rotate to that direction
        Vector3 direction = (_movePosition - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(direction);
        if (rot != _targetRotation)
        {
            _targetRotation = rot;
            _previousRotation = transform.rotation;
            _rotationTime = 0;
        }


        transform.rotation = Quaternion.Lerp(_previousRotation, _targetRotation, _rotationTime += Time.deltaTime * _rotateSpeed);

        //Set the new rotation without the x or z to only rotate on the y axis
        Quaternion newRot = transform.rotation;
        newRot.x = 0;
        newRot.z = 0;
        //Rotate to the new rotation
        transform.rotation = newRot;
    }
}
