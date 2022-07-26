using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationBehavior : MonoBehaviour
{
    private Vector3 _movePosition;
    private Quaternion _targetRotation;
    private float _rotationTime;
    private Quaternion _previousRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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


        transform.rotation = Quaternion.Lerp(_previousRotation, _targetRotation, _rotationTime += Time.deltaTime * 6.5f);

        //Set the new rotation without the x or z to only rotate on the y axis
        Quaternion newRot = transform.rotation;
        newRot.x = 0;
        newRot.z = 0;
        //Rotate to the new rotation
        transform.rotation = newRot;
    }
}
