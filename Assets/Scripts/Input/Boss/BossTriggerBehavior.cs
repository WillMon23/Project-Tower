using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Mon Script
//Date: 07/22/2022
public class BossTriggerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    //Testing Purposese
    private float _insanityGauge = 0;

    private BossMovementBehavior _bossMovement;
    // Start is called before the first frame update
    void Start()
    {
        _bossMovement = GetComponent<BossMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _bossMovement.Direction = (_player.position - transform.position).normalized;
    }
}
