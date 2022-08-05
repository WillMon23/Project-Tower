using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlotBehaviour
{
    //All the data for this item
    [SerializeField]
    private ItemDataBehaviour _itemData;
    //How many of this item you can hold
    [SerializeField]
    private int _stackSize;

    public ItemDataBehaviour ItemData
    {
        get { return _itemData; }
        set { _itemData = value; }
    }

    public int StackSize
    {
        get { return _stackSize; }
        set { _stackSize = value; }
    }

    /// <summary>
    /// Constructor that holds what the inventory slot will contain
    /// </summary>
    /// <param name="itemData">All the data for a paticular item</param>
    /// <param name="stackSize">The amount this item can hold in a stack</param>
    public InventorySlotBehaviour(ItemDataBehaviour itemData, int stackSize)
    {
        _itemData = itemData;
        _stackSize = stackSize;
    }

    /// <summary>
    /// Overload to create an empty slot in inventroy
    /// </summary>
    public InventorySlotBehaviour()
    {
        ClearSlot();
    }

    /// <summary>
    /// Clears out a slot in inventory
    /// </summary>
    public void ClearSlot()
    {
        _itemData = null;
        _stackSize = 0;
    }


    public void UpdateInventorySlot(ItemDataBehaviour data, int stackSize)
    {
        _itemData = data;
        _stackSize = stackSize;
    }

    /// <summary>
    /// Sets an amount that is remaining in the stack and checks if there is room left in the stack or not
    /// </summary>
    /// <param name="amountToAdd">Amount wanting to add to the stack</param>
    /// <param name="amountRemaining">Amount remaining in the stack</param>
    /// <returns></returns>
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        //Set the amount that is remaining in the stack
        amountRemaining = ItemData.MaxStackSize - _stackSize;

        //Return if there is room left in the stack or not
        return RoomLeftInStack(amountToAdd);
    }

    /// <summary>
    /// Checks if there is room in the stack
    /// </summary>
    /// <param name="amountToAdd">Amount of the item wanting to add to stack</param>
    /// <returns></returns>
    public bool RoomLeftInStack(int amountToAdd)
    {
        //If there is room left in the stack...
        if (_stackSize + amountToAdd <= _itemData.MaxStackSize)
            //...return true
            return true;
        //Otherwise there is no room left in the stack...
        else
            //...return false
            return false;
    }

    /// <summary>
    /// Adds an item to the stack of similar item
    /// </summary>
    /// <param name="amount">The amount to add</param>
    public void AddToStack(int amount)
    {
        _stackSize += amount;
    }

    /// <summary>
    /// Removes and item from the stack of items
    /// </summary>
    /// <param name="amount">The amount to remove</param>
    public void RemoveFromStack(int amount)
    {
        _stackSize -= amount;
    }

}
