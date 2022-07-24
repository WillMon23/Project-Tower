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

    private FieldOfView _fieldOfView;

    private BossMovementBehavior _bossMovement;
    // Start is called before the first frame update
    void Start()
    {
        _bossMovement = GetComponent<BossMovementBehavior>();
        _fieldOfView = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_fieldOfView.CanSeePlayer)
            _bossMovement.Direction = (_player.position - transform.position).normalized;

        else
            _bossMovement.Direction = Vector3.zero;
    }
}
