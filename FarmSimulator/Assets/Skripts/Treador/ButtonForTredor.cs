using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForTredor : MonoBehaviour
{
    public int ID;
    public GameObject backPack;


    public void PressPutton()
    {
        for (int i = 0; i < BackPack.vegetable.Count; i++)
        {
            if (BackPack.vegetable[i].ID == ID)
            {
                BackPack.vegetable[i].count++;
            }
            else if(BackPack.vegetable[i].ID == 7)
            {
                BackPack.vegetable[i].ID = ID;
                BackPack.vegetable[i].Image = TreadorMenu._vegetablesFromTreadorinskript[i].Image;
                BackPack.vegetable[i].price = TreadorMenu._vegetablesFromTreadorinskript[i].price;
                BackPack.vegetable[i].name = TreadorMenu._vegetablesFromTreadorinskript[i].name;
                BackPack.vegetable[i].count = 1;



            }
            else
            {
                Debug.Log("your BackPank  dont have anover place");
            }
        }
        backPack.GetComponent<BackPack>().ReDrawInventary();

    }
}
