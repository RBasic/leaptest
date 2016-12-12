using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    private List<Vector3> pointsList;
    
    private Vector3 mousePos;

    public GameObject bout;
    
    [Header("Colors")]
    [SerializeField]
    private Color colorLine;
 
    private bool starTouched = false;

    // Structure for line points
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };
    //    -----------------------------------    
    void Awake()
    {
        // Create line renderer component and set its property
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetVertexCount(0);

        line.SetWidth(0.01f, 0.01f);
        line.SetColors(colorLine, colorLine);
        line.useWorldSpace = true;
        pointsList = new List<Vector3>();
        //        renderer.material.SetTextureOffset(
    }
    //    -----------------------------------   

    void Update()
    {

        line.SetWidth(0.01f, 0.01f);

        mousePos = bout.transform.position;
        Vector3 vec3 = Camera.main.WorldToScreenPoint(mousePos);
        var ray = Camera.main.ScreenPointToRay(vec3);
        var hit = Physics2D.GetRayIntersection(ray);

       
            Debug.Log("hit = " + hit.collider);
            if (hit.collider != null && hit.collider == GameManager.instance.getCurrentConstellation().getCurrentStar().GetComponent<CircleCollider2D>())
            {
            starTouched = true;
                if (GameManager.instance.getCurrentConstellation().setCurrentStar())
                {
                    //changer constellation;
                    Debug.Log("FINI !");

                }

            }


        if (starTouched)
        {
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);

                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

                if (hit.collider != null && hit.collider == GameManager.instance.getCurrentConstellation().getColliderConstellation())
                {
                    Debug.Log("coucou");
                    line.SetColors(colorLine, colorLine);


                }
                else
                {
                    line.SetColors(Color.red, Color.red);
                    GameManager.instance.getOutColldr().SetActive(true);
                }

            }
        }
        
    }
    //    -----------------------------------    
    // Following method checks is currentLine(line drawn by last two points) collided with line
    //    -----------------------------------    
    private bool isLineCollide()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1)
        {
            for (int i = 0; i < TotalLines; i++)
            {
                lines[i].StartPoint = (Vector3)pointsList[i];
                lines[i].EndPoint = (Vector3)pointsList[i + 1];
            }
        }
        for (int i = 0; i < TotalLines - 1; i++)
        {
            myLine currentLine;
            currentLine.StartPoint = (Vector3)pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList[pointsList.Count - 1];
        }
        return false;
    }
    //    -----------------------------------    
    //    Following method checks whether given two points are same or not
    //    -----------------------------------    
    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
  
}
