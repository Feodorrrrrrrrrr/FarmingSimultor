using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public bool _canBeGet = false;
    [SerializeField]
    private int _timeForGrowUp = 5;
   
    private void Start()
    {
        transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        StartCoroutine(GrowUp());
    }
    IEnumerator GrowUp() 
    { 
        transform.localScale = transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        yield return new WaitForSeconds(_timeForGrowUp);
        transform.localScale = transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(_timeForGrowUp);
        transform.localScale = transform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(_timeForGrowUp);
        transform.localScale = transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        yield return new WaitForSeconds(_timeForGrowUp);
        transform.localScale = transform.localScale = new Vector3(2f, 2f, 2f);
        _canBeGet = true;
    }
}
