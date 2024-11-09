using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : DestroyableSingleton<DropItemManager>
{
    public GameObject prefab_pouch;
    public GameObject prefab_potion;


    //금화주머니
    public DropItem GetItem_Pouch(Vector3 pos)
    {
        return Instantiate( prefab_pouch, pos ,Quaternion.identity).GetComponent<DropItem>();
    }


    
    //포션 
    public DropItem GetItem_Potion(Vector3 pos)
    {
        return Instantiate( prefab_pouch, pos ,Quaternion.identity).GetComponent<DropItem>();
    }




}
