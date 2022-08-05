using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpBehaviour : MonoBehaviour
{
    //The data the item holds
    public ItemDataBehaviour ItemData;

    //The collider on the item
    private Collider _myCollider;

    /// <summary>
    /// Initializing the items collider and setting is trigger to true and the start of game
    /// </summary>
    private void Awake()
    {
        _myCollider = GetComponent<Collider>();
        _myCollider.isTrigger = true;
    }

    /// <summary>
    /// On trigger, add item to the empty slot in the inventory system of the inventory holder.
    /// </summary>
    /// <param name="other">The collider on the item</param>
    private void OnTriggerEnter(Collider other)
    {
        //initializes inventory to be the inventory holder that is found on whatever it has collided with
        var inventory = other.transform.GetComponent<InventoryHolderBehaviour>();

        //If an inventory holder was not found...
        if (!inventory)
            //...exit function
            return;

        //If the and inventory holder was found add the item to the inventory system and destroy the game object.
        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
