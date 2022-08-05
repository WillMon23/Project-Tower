using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon
//Date: 07/23/2022
public class FieldOfViewBehavior : MonoBehaviour
{
    [SerializeField]
    private float _radius;

    [SerializeField, Range(0,360)]
    private float _angle;

    private GameObject _playerRef;

    [SerializeField]
    private LayerMask _targetMask;

    [SerializeField]
    private LayerMask _obstruction;

    private RoutineBehaviour.TimedAction _fovRoutine;

    private bool _canSeePlayer;

    private bool _onEnable = true;

    public float Radius { get => _radius; }
    public float Angle { get => _angle; }
    public bool CanSeePlayer { get => _canSeePlayer; }
    public GameObject PlayerRef { get => _playerRef; }

    public void TurnOn () => _onEnable = true;

    public void TurnOff () => _onEnable = false; 

    // Start is called before the first frame update
    void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(.02f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (!_onEnable) return;

        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstruction))
                    _canSeePlayer = true;
                else
                    _canSeePlayer = false;
            }
            else
                _canSeePlayer = false;    
        }
        else if (_canSeePlayer)
                _canSeePlayer = false;
    }

  
}
