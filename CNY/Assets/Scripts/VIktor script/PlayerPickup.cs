using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public void PickUpItem(PickupItem item)
    {
        Debug.Log("Picked up: " + item.itemName);

        switch (item.itemType)
        {
            case PickupItem.ItemType.Health:
                // Example: öka health
                Debug.Log("Health Increased by " + item.value);
                break;

            case PickupItem.ItemType.Coin:
                // Example: öka currency
                Debug.Log("Coins Increased by " + item.value);
                break;

            case PickupItem.ItemType.PowerUp:
                // Example: Aktivera power-up
                Debug.Log("Power-Up Activated!");
                break;
        }

        Destroy(item.gameObject); // tar bort föremål från scenen
    }
}