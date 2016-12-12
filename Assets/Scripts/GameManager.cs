using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject constellations;
    List<Constellation> listConstellations = new List<Constellation>();

    Constellation currentConstellation;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    void Start()
    {
        foreach(Constellation c in constellations.GetComponentsInChildren<Constellation>())
        {
            listConstellations.Add(c);
        }
        if(listConstellations.Count!=0)
            currentConstellation = listConstellations[0];
    }

    public Constellation getCurrentConstellation()
    {
        return currentConstellation;
    }

    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;
}
