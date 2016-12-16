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

    [SerializeField]
    string loose;
    [SerializeField]
    string loose1;
    bool isLoose = false;

    [SerializeField]
    string win;
    [SerializeField]
    string win2;
    bool isWin = false;

    [SerializeField]
    Text instructions;

    [SerializeField]
    GameObject end;

    int index = -1;

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
        foreach (Constellation c in constellations.GetComponentsInChildren<Constellation>(true))
        {
            listConstellations.Add(c);
        }
        if (listConstellations.Count != 0)
        {
            changeCurrentConstellation();
        }
    }

    public Constellation getCurrentConstellation()
    {
        return currentConstellation;
    }

    public void changeCurrentConstellation()
    {
        index++;
        if (index < listConstellations.Count)
        {
            if(currentConstellation!=null)
                currentConstellation.gameObject.SetActive(false);
            currentConstellation = listConstellations[index];
            currentConstellation.gameObject.SetActive(true);
            clearInstructions();
            nameCurrentContellation.text = currentConstellation.getName();
            changeBackground();
        }
        // else end of the game
        else
        {
            currentConstellation.gameObject.SetActive(false);
            end.SetActive(true);
        }
    }

    public void reload()
    {
        currentConstellation.reload();
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

    public void looseInstructions()
    {
        instructions.text = loose;
        instructions.text += "\n";
        instructions.text += loose1;
    }

    public void winInstructions()
    {
        instructions.text = win;
        instructions.text += "\n";
        instructions.text += win2;
    }

    public void clearInstructions()
    {
        instructions.text = "";
    }

    public void setLoose(bool state)
    {
        isLoose = state;
    }

    public bool getLoose()
    {
        return isLoose;
    }

    public void setWin(bool state)
    {
        isWin = state;
    }

    public bool getWin()
    {
        return isWin;
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
