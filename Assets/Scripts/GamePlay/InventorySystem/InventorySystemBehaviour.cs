using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystemBehaviour
{
    //List of slots in the inventory
    [SerializeField]
    private List<InventorySlotBehaviour> _inventorySlots;

    public List<InventorySlotBehaviour> InventorySlots
    {
        get { return _inventorySlots; }
        set { _inventorySlots = value; }
    }

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlotBehaviour> OnInventorySlotChange;

    /// <summary>
    /// Constructor for the size of the inventory
    /// </summary>
    /// <param name="size"></param>
    public InventorySystemBehaviour(int size)
    {
        //Initialize a list of slots in the inventroy
        _inventorySlots = new List<InventorySlotBehaviour>(size);

        //Creates empty slots for the total size of the inventory
        for (int i = 0; i < size; i++)
        {
            _inventorySlots.Add(new InventorySlotBehaviour());
        }
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="itemToAdd">The item being added to the inventory</param>
    /// <param name="amountToAdd">The amount of this item being picked up</param>
    /// <returns></returns>
    public bool AddToInventory(ItemDataBehaviour itemToAdd, int amountToAdd)
    {
        InventorySlots[0] = new InventorySlotBehaviour(itemToAdd, amountToAdd);
        return true;
        ////If item exists in inventory...
        //if(ContainsItem(itemToAdd, out InventorySlotBehaviour invSlot))
        //{
        //    //...add item to the stack
        //    invSlot.AddToStack(amountToAdd);
        //    //change the slot
        //    OnInventorySlotChange?.Invoke(invSlot);
        //    //Return true
        //    return true;
        //}
        ////else if item does not already exist in inventory, If there is a free slot in inventory...
        //else if (HasFreeSlot(out InventorySlotBehaviour freeSlot))
        //{
        //    //...add the item and the item amount to the free slot
        //    freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
        //    //Call the slot change
        //    OnInventorySlotChange?.Invoke(freeSlot);
        //    //return true.
        //    return true;
        //}

        //return false;
    }

    public bool ContainsItem(ItemDataBehaviour iteamToAdd, out InventorySlotBehaviour invSlot)
    {
        invSlot = null;
        return false;
    }

    public bool HasFreeSlot(out InventorySlotBehaviour freeSlot)
    {
        freeSlot = null;
        return false;
    }
}
