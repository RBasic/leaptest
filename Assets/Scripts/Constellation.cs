using UnityEngine;
using System.Collections.Generic;

public class Constellation : MonoBehaviour {

    [SerializeField]
    string nameConstellation;
    [SerializeField]
    Collider2D colliderConstellation;
    [SerializeField]
    List<GameObject> stars = new List<GameObject>();
    private GameObject currentStar;
    private int index;
    LineRenderer line;

	// Use this for initialization
	void Start () {
        index = 0;
        currentStar = stars[index];
        
	}
	
    public void reload()
    {
        for(int i = 0; i < stars.Count; i++)
        {
            stars[i].GetComponentInChildren<CircleCollider2D>().enabled = true;
            stars[i].GetComponentInChildren<MeshRenderer>().enabled = true;

            stars[i].SetActive(false);
            
        }
        index = 0;
        currentStar = stars[index];
        currentStar.SetActive(true);

    }
    // Update is called once per frame
    void Update () {

        //Debug.Log("index = " + index);
	}

    public Collider2D getColliderConstellation()
    {
        return colliderConstellation;
    }

    public GameObject getCurrentStar()
    {
        return currentStar;
    }
    public bool setCurrentStar()
    {
        index++;
        if (index >= 2)
        {
            LineRenderer[] lrtab = currentStar.GetComponentsInChildren<LineRenderer>();
            foreach(LineRenderer l in lrtab)
            {
                l.enabled = true;
            }
        }
        currentStar.GetComponentInChildren<CircleCollider2D>().enabled = false;
        currentStar.GetComponentInChildren<MeshRenderer>().enabled = false;

        if (index == stars.Count)
        {
            return true;
        }

        currentStar = stars[index];
        currentStar.SetActive(true);
        return false;

        /*index++;
        if (index >= 2)
        {
            line = currentStar.GetComponent<LineRenderer>();
            line.SetPosition(0, stars[index - 2].transform.position);
            line.SetPosition(1, stars[index-1].transform.position);
        }

        currentStar.GetComponentInChildren<CircleCollider2D>().enabled = false;
        currentStar.GetComponentInChildren<MeshRenderer>().enabled = false;
        if (index == stars.Count)
        {
            return true;
        }
        currentStar = stars[index];
        currentStar.SetActive(true);
        return false;*/
    }

    public string getName()
    {
        return nameConstellation;
    }
}
