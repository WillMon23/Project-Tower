using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon Script
//Date: 07/22/2022

public enum BossPhase { IDLE, WONDER, SEARCH, INSIGHT }

public class BossTriggerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Transform _pointOfOrgin;

    float _timer = 0;
    [SerializeField,Range(0f, 10f)]
    private float _timedOut;

    private FieldOfViewBehavior _fieldOfView;

    private BossMovementBehavior _bossMovement;

    private bool _isFollowing;

    public bool IsFollowing { get => _isFollowing; }
    // Start is called before the first frame update
    void Start()
    {
        //In the case we want to see the point of orgion manualy 
        if (_pointOfOrgin == null)
            _pointOfOrgin = transform;

        _bossMovement = GetComponent<BossMovementBehavior>();
        _fieldOfView = GetComponent<FieldOfViewBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        ICanSeeYou();
    }

    /// <summary>
    /// Checks Field of view to see if the target is in range 
    /// Once the target is in range it'll attack
    /// After a mommnet in time out of range 
    /// The Object will then Stop Persuring 
    /// </summary>
    private void ICanSeeYou()
    {
        //Checks the field of view and checks the timer
        if (_fieldOfView.CanSeePlayer && _timedOut >= _timer)
        {
            _bossMovement.Direction = (_player.position - transform.position).normalized;
            _timer = 0;
            _isFollowing = true;
        }

        //If target can't be seen but the time is not up we add to the timer 
        else if (!_fieldOfView.CanSeePlayer && _timedOut >= _timer)
            _timer += Time.deltaTime;

        else
        {
            _bossMovement.Direction = Vector3.zero;
            _timer = 0;
            _isFollowing = false;
        }
    }
}
