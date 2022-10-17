using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerS : MonoBehaviour
{
    public RingS inHand;

    public GameObject towerPrefab;
    public GameObject ringPrefab;
    public RingS[] ringArr;
    public TowerS[] towerArr;
    public int numRings;
    // Start is called before the first frame update
    void Start()
    {
        ringArr = new RingS[numRings];
        towerArr = new TowerS[3];
        createTowers();
        createRings();
        towerArr[0].pushRing(ringArr[0]);
        //towerArr[1].pushRing(ringArr[1]);
        //towerArr[2].pushRing(ringArr[2]);

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
        
        for(int i = 0; i < 1; i++)
        {

            Vector3 ratio = new Vector3((float)(300-(300*scaleRat*i)), 75f, 1f);
            ringArr[i] = GameObject.Instantiate(ringPrefab,new Vector3(0,0,0),Quaternion.identity).GetComponent<RingS>();
            ringArr[i].transform.localScale = (ratio);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
