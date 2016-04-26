using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Bar : MonoBehaviour {

    public Image barImage;

    // Use this for initialization
    void Start () {
        barImage = GetComponent<Image>();
    }


    public void BarUpdate(float max, float damage, int type)
    {
        float mov = max - damage;

        if(mov == 0)
        {
            mov = 1;
        }
        barImage.fillAmount = mov / max;

        if(barImage.fillAmount < 0.3)
        {
            barImage.color = Color.red;
        }
        else
        {
            switch(type)
            {
                case 0:
                    barImage.color = Color.green;
                    break;
                case 1:
                    barImage.color = Color.blue;
                    break;
            }
           
        }
    }
  
}
