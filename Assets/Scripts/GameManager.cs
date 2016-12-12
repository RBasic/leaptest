using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject constellations;
    List<Constellation> listConstellations = new List<Constellation>();

    Constellation currentConstellation;
    [SerializeField]
    Text nameCurrentContellation;

    [SerializeField]
    GameObject backgrounds;
    List<SpriteRenderer> listBackgrounds = new List<SpriteRenderer>();
    int indexCurrentBakground = -1;

    [SerializeField]
    GameObject outCollider;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    void Start()
    {
        foreach (SpriteRenderer sp in backgrounds.GetComponentsInChildren<SpriteRenderer>(true))
        {
            listBackgrounds.Add(sp);
        }
        foreach (Constellation c in constellations.GetComponentsInChildren<Constellation>())
        {
            listConstellations.Add(c);
        }
        if (listConstellations.Count != 0)
            changeCurrentConstellation(0);
    }

    public Constellation getCurrentConstellation()
    {
        return currentConstellation;
    }

    void changeCurrentConstellation(int index)
    {
        currentConstellation = listConstellations[index];
        nameCurrentContellation.text = currentConstellation.getName();
        changeBackground();
    }

    void changeBackground()
    {
        if (indexCurrentBakground != -1)
        {
            listBackgrounds[indexCurrentBakground].gameObject.SetActive(false);
        }
        indexCurrentBakground = Random.Range(0,listBackgrounds.Count);
        listBackgrounds[indexCurrentBakground].gameObject.SetActive(true);
    }

    public GameObject getOutColldr()
    {
        return outCollider;
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
