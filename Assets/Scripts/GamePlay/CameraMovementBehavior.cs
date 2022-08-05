using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehavior : MonoBehaviour
{
    private Vector3 _movePosition;
    [SerializeField]
    private PlayerMovementBehavior _player;
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

        _movePosition.y = transform.position.y;
        _movePosition.x = Mathf.Clamp(_movePosition.x, _player.transform.position.x - 6, _player.transform.position.x + 6);
        _movePosition.z = Mathf.Clamp(_movePosition.z, _player.transform.position.z - 4, _player.transform.position.z + 4);



        transform.position = Vector3.Lerp(transform.position, _movePosition, 2f * Time.deltaTime);
    }
}
