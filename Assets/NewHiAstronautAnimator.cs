using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHiAstronautAnimator : MonoBehaviour
{
    public int speed = 5;
    // Start is called before the first frame update
    void Update(){
        transform.Rotate(0,speed,0);
    }
}
