using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon
//Date: 07/23/2022
public class FieldOfView : MonoBehaviour
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

    bool _canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        _fovRoutine = RoutineBehaviour.Instance.StartNewTimedAction(arg => FieldOfViewCheck(), TimedActionCountType.SCALEDTIME, .02f);

    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (transform.position - target.position).normalized;

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
