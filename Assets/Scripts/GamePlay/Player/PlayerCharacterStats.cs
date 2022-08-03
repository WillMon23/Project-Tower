using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Create New Character")]
public class PlayerCharacterStats : ScriptableObject
{
    /// <summary>
    /// Determines how quickly the character's light power drains.
    /// </summary>
    [SerializeField]
    private float _lightLongevity;

    /// <summary>
    /// Determines how fast the character will be able to move.
    /// </summary>
    [SerializeField]
    private float _movementSpeed;

    /// <summary>
    /// Determines how fast the insanity meter fills up.
    /// </summary>
    [SerializeField]
    private float _mentalStability;

    /// <summary>
    /// Determines how quickly the character's light power drains.
    /// </summary>
    public float LightLongevity { get { return _lightLongevity; } }

    /// <summary>
    /// Determines how fast the character will be able to move.
    /// </summary>
    public float MovementSpeed { get { return _movementSpeed; } }

    /// <summary>
    /// Determines how fast the insanity meter fills up.
    /// </summary>
    public float MentalStability { get { return _mentalStability; } }
}
