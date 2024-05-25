using UnityEngine;

public class Button : MonoBehaviour
{
    public BackPack myInv;
    public int myID;
    public string _from;

    public void PressPutton()
    {
        myInv.SelectSlot(myID, _from);
    }
}
