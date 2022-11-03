using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerS : MonoBehaviour
{
    public RingS inHand;

    public GameObject towerPrefab;
    public GameObject ringPrefab;
    public RingS[] ringArr;
    public TowerS[] towerArr;
    public TMP_Text moveCountText;
    public int numRings;
    public int moves;
    
    void Start()
    {
        moves = 0;
        moveCountText = GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>();
        numRings = 3;
        ringArr = new RingS[numRings];
        towerArr = new TowerS[3];
        createTowers();
        createRings();

    }

    public void newRingCt()
    {
        removeClutter();
        moves = -1;
        moveTaken();
        ringArr = new RingS[numRings];
        towerArr = new TowerS[3];
        createTowers();
        createRings();
    }

    void removeClutter()
    {
        if(inHand != null)
        {
            inHand.selfDest();
        }
        foreach(TowerS theTower in towerArr)
        {
            theTower.selfDest();
        }
    }

    void createTowers()
    {
        towerArr[0] = GameObject.Instantiate(towerPrefab,new Vector3(-6,0,0), Quaternion.identity).GetComponent<TowerS>();
        towerArr[0].towerVal = 1;
        towerArr[0].createTow(numRings);
        towerArr[1] = GameObject.Instantiate(towerPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<TowerS>();
        towerArr[1].towerVal = 2;
        towerArr[1].createTow(numRings);
        towerArr[2] = GameObject.Instantiate(towerPrefab, new Vector3(6, 0, 0), Quaternion.identity).GetComponent<TowerS>();
        towerArr[2].towerVal = 3;
        towerArr[2].createTow(numRings);
    }

    void createRings() 
    {
        double scaleRat = (0.5 / numRings);
        
        for(int i = 0; i < numRings; i++)
        {

            Vector3 ratio = new Vector3((float)(1.25*(2-(scaleRat*i))), .75f, 1f);
            ringArr[i] = GameObject.Instantiate(ringPrefab,new Vector3(0,0,-1),Quaternion.identity).GetComponent<RingS>();
            ringArr[i].transform.localScale = (ratio);
            ringArr[i].size = numRings - i;
            ringArr[i].colorIn();
            towerArr[0].pushRing(ringArr[i]);
        }
    }

    public void moveTaken()
    {
        moves++;
        moveCountText.text = "Moves: " + moves;
    }

    public void solveItStarter()
    {
        StartCoroutine(solveIt(numRings));
    }
    public IEnumerator solveIt(int n, int from = 0, int to = 2, int other = 1)
    {
        if(n == 0)
        {
            yield break;
        }
        Debug.Log("Mlr");
        solveIt(n - 1, from, other, to);

        yield return StartCoroutine(waitCoroutine(from, to));
        
        solveIt(n - 1, other, to, from);
    }

    IEnumerator waitCoroutine(int from2, int to2)
    {
        Debug.Log("Mart");
        yield return new WaitForSeconds(1.0f);
        towerArr[to2].pushRing(towerArr[from2].removeTop());
    }


    void Update()
    {
        
    }
}
