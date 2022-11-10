using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
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
        getManager();
    }

    public void pushRing(RingS theRing)
    {
        tRingArr[currCount] = theRing;
        currCount++;
        topValue = theRing.size;

        theRing.transform.SetParent(gameObject.transform);
        theRing.clipped = false;
        theRing.GetComponent<BoxCollider2D>().enabled = true;
        theRing.transform.localPosition = new Vector3(0f, ((currCount - 1)*0.150f - 0.425f), -1f);

        if(towerVal == 3) { checkVic(); }
    }

    public void OnMouseUpAsButton()
    {
        if (theManager.inHand != null && theManager.inHand.size < topValue)
        {
            pushRing(theManager.inHand);
            theManager.inHand = null;
        }
    }

    public RingS removeTop()
    {
        RingS theRef = tRingArr[currCount - 1];
        tRingArr[currCount - 1] = null;
        currCount--;
        if (currCount == 0) {topValue = 100; }
        else {topValue = tRingArr[currCount - 1].size; }
        if (theManager != null)
        {
            theManager.moveTaken();
        }
        else
        {
            Debug.Log("No Manager" + gameObject.name);
        }
        return theRef;
    }

    public void Start()
    {
        getManager();
    }

    public void checkVic()
    {
        if(currCount == theManager.numRings)
        {
            Debug.Log("VicRoy");
        }
    }

    public void getManager()
    {
        if (theManager == null)
        {
            theManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerS>();
        }
    }

    public void selfDest()
    {
        foreach(RingS theRing in tRingArr)
        {
            if (theRing != null)
            {
                theRing.selfDest();
            }
        }
        Destroy(gameObject);
    }
}
