using UnityEngine;
using System.Collections.Generic;

public class Constellation : MonoBehaviour {

    [SerializeField]
    Collider2D colliderConstellation;
    [SerializeField]
    List<GameObject> stars = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Collider2D getColliderConstellation()
    {
        return colliderConstellation;
    }
}
