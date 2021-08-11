using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//no idea but ok
[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    /*this is just to create a list of items in a inventory that appears under the player section in unity*/
    //later we will make that into an actual UI
    new public string name = "new item";
    public Sprite icon = null;
}

