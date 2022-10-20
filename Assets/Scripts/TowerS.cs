using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerS : MonoBehaviour
{
    public int topValue;
    public int towerVal;
    public int currCount;
    public int maxCount;
    public GameManagerS theManager;

    public RingS[] tRingArr;
    public void createTow(int max)
    {
        maxCount = max;
        currCount = 0;
        tRingArr = new RingS[maxCount];
        topValue = 100;
    }

    public void pushRing(RingS theRing)
    {
        currCount = 0;
        tRingArr[currCount] = theRing;
        theRing.transform.SetParent(gameObject.transform);
        currCount++;
        theRing.clipped = false;
        theRing.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void OnMouseUpAsButton()
    {
        if (theManager.inHand != null && theManager.inHand.size < topValue)
        {
            pushRing(theManager.inHand);
            theManager.inHand = null;
        }
        Debug.Log("Clicked" + gameObject.name);
    }

    public void Start()
    {
        theManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerS>();
    }
}
