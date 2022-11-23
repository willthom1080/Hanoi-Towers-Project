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
    public TMP_Text victoryText;
    public GameObject victoryOblong;
    public int numRings;
    public int moves;

    private bool solving;
    
    void Start()
    {
        moves = 0;
        moveCountText = GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>();
        numRings = 3;
        ringArr = new RingS[numRings];
        towerArr = new TowerS[3];
        createTowers();
        createRings();
        solving = false;
    }

    public void newRingCt()
    {
        StopAllCoroutines();
        removeClutter();
        moves = -1;
        moveTaken();
        ringArr = new RingS[numRings];
        towerArr = new TowerS[3];
        createTowers();
        createRings();
        solving = false;
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
        victoryOblong.GetComponent<SpriteRenderer>().enabled = false;
        victoryText.enabled = false;
    }

    void createTowers()
    {
        towerArr[0] = GameObject.Instantiate(towerPrefab, Camera.main.ScreenToWorldPoint(new Vector3((Camera.main.pixelWidth / 3), (Camera.main.pixelHeight / 2),10)), Quaternion.identity).GetComponent<TowerS>();
        towerArr[0].towerVal = 1;
        towerArr[0].createTow(numRings);
        towerArr[1] = GameObject.Instantiate(towerPrefab, Camera.main.ScreenToWorldPoint(new Vector3((Camera.main.pixelWidth / 2), (Camera.main.pixelHeight / 2), 10)), Quaternion.identity).GetComponent<TowerS>();
        towerArr[1].towerVal = 2;
        towerArr[1].createTow(numRings);
        towerArr[2] = GameObject.Instantiate(towerPrefab, Camera.main.ScreenToWorldPoint(new Vector3((Camera.main.pixelWidth / 3)*2, (Camera.main.pixelHeight / 2), 10)), Quaternion.identity).GetComponent<TowerS>();
        towerArr[2].towerVal = 3;
        towerArr[2].createTow(numRings);
    }

    void createRings() 
    {
        double scaleRat = (1.0 / numRings);
        
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
        if (!(solving))
        {
            solving = true;
            newRingCt();
            if (moves == 0)
            {
                StartCoroutine(solveIt(numRings));
            }
        }
    }
    public IEnumerator solveIt(int n, int from = 0, int to = 2, int other = 1)
    {
        if(n == 0)
        {
            yield break;
        }
       
        yield return StartCoroutine(solveIt(n - 1, from, other, to));

        yield return StartCoroutine(stepCoroutine(from, to));

        yield return StartCoroutine(solveIt(n - 1, other, to, from));
    }

    IEnumerator stepCoroutine(int from2, int to2)
    {
        yield return new WaitForSeconds(1.0f);
        towerArr[to2].pushRing(towerArr[from2].removeTop());
    }

    public void vicRoy()
    {
        victoryOblong.GetComponent<SpriteRenderer>().enabled = true;
        victoryText.enabled = true;
        solving = false;
    }
    void Update()
    {
        
    }
}
