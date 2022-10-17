using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerS : MonoBehaviour
{
    public int topValue;
    public int towerVal;
    public int currCount;
    public int maxCount;

    public RingS[] tRingArr;
    public void createTow(int max)
    {
        maxCount = max;
        currCount = 0;
        tRingArr = new RingS[maxCount];
    }

    public void pushRing(RingS theRing)
    {
        currCount = 0;
        tRingArr[currCount] = theRing;
        theRing.transform.SetParent(gameObject.transform);
        currCount++;
    }
    
}
