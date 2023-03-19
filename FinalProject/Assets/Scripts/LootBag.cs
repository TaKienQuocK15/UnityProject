using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    
    public List<Loot> LootList;
    // Start is called before the first frame update
    Loot getDroppedItem()
    {
        int randomNum = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in LootList)
        {
            if(randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("no loot, no maiden?");
        return null;


    }
    public void dropLoot(Vector3 pos)
    {
        Loot droppedItem = getDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItem.LootPrefab, pos, Quaternion.identity);
        }
    }
}
