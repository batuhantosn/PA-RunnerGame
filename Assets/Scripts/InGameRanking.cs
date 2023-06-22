using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    public Text[] nameText;
    public string a,b,c,d,e;

    // Update is called once per frame
    void Update()
    {
        nameText[0].text = a;
        nameText[1].text = b;
        nameText[2].text = c;
        nameText[3].text = d;
        nameText[4].text = e;
    }
}
