using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderS : MonoBehaviour
{
    public Slider theSlider;
    public GameManagerS theManager;
    public TMP_Text ringCountText;
    // Start is called before the first frame update
    void Start()
    {
        theSlider.onValueChanged.AddListener((v) =>
        {
            theManager.numRings = (int)v;
            theManager.newRingCt();
            ringCountText.text = (int)v + " Rings";
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
