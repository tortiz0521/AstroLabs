using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //This component is placed on any object that is a keyItem pick up and to be placed in your "inventory"
    [Header("Inventory System: Item Details")]
    public string itemName = "Item";
    public int itemID = 0;
    public bool destroyOnUse = false;
    public Sprite displaySprite;
    public Color spriteDye = new Color(1.0f,1.0f,1.0f, 1.0f);

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.TryGetComponent<PlayerInventory>(out PlayerInventory inv);
            inv.AddItemToInventory(new PlayerInventory.Item(itemName, itemID, displaySprite, spriteDye, destroyOnUse));

            this.gameObject.SetActive(false);
        }
    }
}
