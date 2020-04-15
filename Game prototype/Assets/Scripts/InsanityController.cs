using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityController : MonoBehaviour
{
    float barWidth;
    float sanity;
    float maxSanity = 100;
    public Image insanityBar;

    void Start(){
    	sanity = maxSanity;
    	insanityBar.fillAmount = sanity/maxSanity;
    }

    public void AddInsanity(int subtract){
    	sanity -= subtract;
    	insanityBar.fillAmount = sanity/maxSanity;
    	Debug.Log(insanityBar.fillAmount);
    }
}
