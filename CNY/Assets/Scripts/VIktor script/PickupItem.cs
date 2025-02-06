using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public enum ItemType { Health, Coin, PowerUp }
    public ItemType itemType;
    public string itemName = "Default Item";
    public int value = 1; // Value of the item (e.g., health amount, coin value)

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPickup player = other.GetComponent<PlayerPickup>();

        if (player != null)
        {
            player.PickUpItem(this); // Call the function on the player
        }
    }
}
