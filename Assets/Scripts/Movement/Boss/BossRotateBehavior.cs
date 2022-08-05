using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotateBehavior : MonoBehaviour
{
    public float _speed = 5f;

    private float _timer = 0f;

    [SerializeField]
    private float _timedOut = 3f;

    private GameObject _playerRef;
    private Rigidbody _rb;
    private BossTriggerBehavior _boss;



    
    // Start is called before the first frame update
    void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _boss = GetComponent<BossTriggerBehavior>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Checks the field of view and checks the timer
        if (_boss.IsFollowing)
        {
            Quaternion rot = Quaternion.LookRotation(_playerRef.transform.position - transform.position);
            Quaternion yRotation = Quaternion.identity;

            yRotation.eulerAngles = new Vector3(0, rot.eulerAngles.y, 0);

            _rb.rotation = Quaternion.RotateTowards(transform.rotation, yRotation, _speed * Time.deltaTime);

            _timer = 0;
        }

        else if (!_boss.IsFollowing && _timedOut >= _timer)
        {
            _timer += Time.deltaTime;
            _timer = 0;
        }

        
    }
}
