using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingS : MonoBehaviour
{
    public bool clipped;
    public GameManagerS theManager;
    public Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        clipped = false;
        theManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerS>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clipped)
        {
            mousePos = Input.mousePosition;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
        
    }

    void OnMouseUpAsButton()
    {
        if (theManager.inHand == null)
        {
            clipped = true;
            theManager.inHand = this;
            transform.parent = null;
        }
    }
}
