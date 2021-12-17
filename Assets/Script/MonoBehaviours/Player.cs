using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;

    HealthBar healthBar;

    public void Start()
    {
        hitPoints.value = startingHitPoints;

        healthBar = Instantiate(healthBarPrefab);

        healthBar.character = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool shouldDisapper = false;

                print("Hit: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.DROP:
                        shouldDisapper = true;
                        break;

                    case Item.ItemType.HPPOTION:
                        shouldDisapper = AdjustHitPoints(hitObject.quantity);
                        break;

                    default:
                        break;
                }
                if (shouldDisapper)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
    // Start is called before the first frame update
    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value += amount;

            print("Adjusted hitpoints by: " + amount + ", New value: " + hitPoints);

            return true;
        }

        return false;
    }
}
