using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolderBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _inventorySize;
    [SerializeField]
    protected InventorySystemBehaviour _inventorySystem;

    public InventorySystemBehaviour InventorySystem
    {
        get { return _inventorySystem; }
        set { _inventorySystem = value; }
    }

    public static UnityAction<InventorySystemBehaviour> OnDynamicInventoryDisplayRequested;

    void Awake()
    {
        _inventorySystem = new InventorySystemBehaviour(_inventorySize);
    }
}
