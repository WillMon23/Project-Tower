using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlashlightBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject flashlight;
    private bool _flashlightActive = false;


    // Start is called before the first frame update
    void Start()
    {
        flashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
            {
                Destroy(hitinfo.transform.gameObject);
            }

            flashlight.gameObject.SetActive(true);
            _flashlightActive = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            flashlight.gameObject.SetActive(false);
            _flashlightActive = false;
        }
    }
}
