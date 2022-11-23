using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingS : MonoBehaviour
{
    public bool clipped;
    public GameManagerS theManager;
    public TowerS parTow;
    public int size;
    public int prevTow;

    void Start()
    {
        clipped = false;
        theManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerS>();
        prevTow = 1;
    }

    void Update()
    {
        if (clipped)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 8));
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
        float red = 0f;
        float green = 0f;
        float blue = 0f;
        switch (size)
        {
            case 1: red = 255f; break;
            case 2: red = 255f; green = 255f; break;
            case 3: green = 255f; break;
            case 4: green = 255f; blue = 255; break;
            case 5: blue = 255f; break;
            case 6: red = 255f; blue = 255f; break;
            case 7: red = 255f; green = 127f; blue = 127f; break;
        }
        this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
    }

    public void selfDest()
    {
        Destroy(gameObject);
    }
}
