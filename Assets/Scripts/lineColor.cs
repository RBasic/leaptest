using UnityEngine;
using System.Collections;

public class lineColor : MonoBehaviour {


    Color color1 = new Color(1, 1, 0, 0);
    Color color2 = new Color(1, 1, 0, 1);
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    float t = 0;
    float add = 0;
    float add2 = 1;
    float min = 0;
    float max = 1;
    void Update()
    {
        add = Mathf.Lerp(min, max, t);
        add2 = Mathf.Lerp(max, min, t);
        t += Time.deltaTime;
        if (t > 1.0f)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0.0f;
        }
        color1.a = add;
        color2.a = add2;
        GetComponent<LineRenderer>().SetColors(color1, color2);
    }
}
