using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon Script
//Date: 07/22/2022aaaa
public enum BossPhase { IDLE, WONDER, SEARCH, INSIGHT, RETURN }

public class BossTriggerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Vector3 _pointOfOrgin;

    float _timer = 0;
    float _stoppedTimer = 0;

    [SerializeField,Range(0f, 10f)]
    private float _timedOut;

    private FieldOfViewBehavior _fieldOfView;

    private BossMovementBehavior _bossMovement;

    private bool _isFollowing;

    private BossPhase _currentPhase;

    private Vector3 _lastPlayerPosition;


    public bool IsFollowing { get => _isFollowing; } 
    public BossPhase CurrentPhase { get => _currentPhase; }
    // Start is called before the first frame update
    void Awake()
    {
        //In the case we want to see the point of orgion manualy 
        if (_pointOfOrgin == null)
            _pointOfOrgin = transform.position;

        _bossMovement = GetComponent<BossMovementBehavior>();
        _fieldOfView = GetComponent<FieldOfViewBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        PhaseChanger();
        TurningPhases();
    }

    /// <summary>
    /// Checks Field of view to see if the target is in range 
    /// Once the target is in range it'll attack
    /// After a mommnet in time out of range 
    /// The Object will then Stop Persuring a
    /// </summary>
    private void PhaseChanger()
    {
        //Checks the field of view and checks the timer
        if (_fieldOfView.CanSeePlayer)
        {
            _currentPhase = BossPhase.INSIGHT;
            _timer = 0;
            _stoppedTimer = 0;
        }

        //If target can't be seen but the time is not up we add to the timer 
        else if (!_fieldOfView.CanSeePlayer && _timedOut >= _timer)
        {
            _currentPhase = BossPhase.INSIGHT;
            _timer += Time.deltaTime;
        }

        else if (!_fieldOfView.CanSeePlayer && _timedOut <= _timer && _timedOut >= _stoppedTimer)
        {
            _lastPlayerPosition = _player.transform.position;
            _currentPhase = BossPhase.IDLE;
        }

        else if (_timedOut <= _stoppedTimer)
            _currentPhase = BossPhase.SEARCH;

        if(_timedOut >= _stoppedTimer)
            _stoppedTimer += Time.deltaTime;
          
    }

    /// <summary>
    /// Handles the bosses states
    /// </summary>
    private void TurningPhases()
    {
        switch(CurrentPhase)
        {
            case BossPhase.IDLE:
                StandStill();
                break;
            case BossPhase.WONDER:
                break;
            case BossPhase.SEARCH:
                SearchPlayer();
                break;
            case BossPhase.INSIGHT:
                ISeeYou();
                break;
            case BossPhase.RETURN:
                GoBackToStart();
                break;
        }

    }

    /// <summary>
    /// Sets the boss still for the moment
    /// </summary>
    private void StandStill()
    {
        _bossMovement.Direction = Vector3.zero;
        _isFollowing = false;
    }

    /// <summary>
    /// Heads the boss to the last know spot 
    /// </summary>
    private void SearchPlayer()
    {
        _isFollowing = false;
        _bossMovement.Direction = (_lastPlayerPosition - transform.position).normalized;

        if((_lastPlayerPosition - transform.position).magnitude <= 0)
            _currentPhase = BossPhase.RETURN;
        
    }

    /// <summary>
    /// Sets the conditions to go where the line of sight is presented 
    /// </summary>
    private void ISeeYou()
    {
        _fieldOfView.TurnOn();
        _bossMovement.Direction = transform.forward;
        _isFollowing = true;
    }

    /// <summary>
    /// Heads from the current spot to the point of orgin
    /// </summary>
    private void GoBackToStart()
    {
        _isFollowing = false;
        _bossMovement.Direction = (_pointOfOrgin - transform.position).normalized;
    }

}
