﻿using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

    void Start()
    {
        //Change Foreground to the layer you want it to display on 
        //You could prob. make a public variable for this
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
    }
}
