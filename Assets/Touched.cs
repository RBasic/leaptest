using UnityEngine;
using System.Collections;

public class Touched : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void touch()
    {

        Debug.Log("touched");
    }
}
