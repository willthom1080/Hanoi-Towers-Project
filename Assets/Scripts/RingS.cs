using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingS : MonoBehaviour
{
    public bool clipped;
    public GameManagerS theManager;
    public TowerS parTow;
    public int size;

    void Start()
    {
        clipped = false;
        theManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerS>();
        
    }

    void Update()
    {
        if (clipped)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 9));
        }
        
    }

    void OnMouseUpAsButton()
    {
        if (theManager.inHand == null && GetComponentInParent<TowerS>().topValue == size)
        {
            parTow = GetComponentInParent<TowerS>();
            parTow.removeTop();
            clipped = true;
            theManager.inHand = this;
            transform.parent = null;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void colorIn()
    {
        float red = .10f;
        float green = .10f;
        float blue = .10f;
        red *= size+1;
        green *= (size+1)%2;
        blue *= size+1;
        this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
    }

    public void selfDest()
    {
        Destroy(gameObject);
    }
}
