using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    private List<Vector3> pointsList;
    
    private Vector3 mousePos;

    public GameObject bout;

    [SerializeField]
    private GameObject startGameObject;
    [SerializeField]
    private Collider2D colliderSpell;
    
    [Header("Colors")]
    [SerializeField]
    private Color colorStart;
    [SerializeField]
    private Color colorEnd;

    private bool startSpell = false;

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
        line.SetWidth(0.1f, 0.05f);
        line.SetColors(colorStart, colorEnd);
        line.useWorldSpace = true;
        pointsList = new List<Vector3>();
        //        renderer.material.SetTextureOffset(
    }
    //    -----------------------------------   

    void Update()
    {

        line.SetColors(Color.green, Color.green);
        line.SetWidth(0.01f, 0.01f);

        mousePos = bout.transform.position;
        Vector3 vec3 = Camera.main.WorldToScreenPoint(mousePos);
        var ray = Camera.main.ScreenPointToRay(vec3);
        var hit = Physics2D.GetRayIntersection(ray);

        if (!startSpell)
        {
            if (hit.collider != null && hit == startGameObject)
            {
                startSpell = true;
                Debug.Log("start spell ! ");
            }
        }
        else
        {

            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);

                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

              
                startGameObject.transform.position = mousePos;
                startGameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);


                if (hit.collider != null && hit.collider == GameManager.instance.getCurrentConstellation().getColliderConstellation())
                {
                    Debug.Log("coucou");
                }

                if (isLineCollide())
                {
                    line.SetColors(Color.red, Color.red);
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
            if (isLinesIntersect(lines[i], currentLine))
                return true;
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
    //    -----------------------------------    
    //    Following method checks whether given two line intersect or not
    //    -----------------------------------    
    private bool isLinesIntersect(myLine L1, myLine L2)
    {
        if (checkPoints(L1.StartPoint, L2.StartPoint) ||
            checkPoints(L1.StartPoint, L2.EndPoint) ||
            checkPoints(L1.EndPoint, L2.StartPoint) ||
            checkPoints(L1.EndPoint, L2.EndPoint))
            return false;

        return ((Mathf.Max(L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min(L2.StartPoint.x, L2.EndPoint.x)) &&
            (Mathf.Max(L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min(L1.StartPoint.x, L1.EndPoint.x)) &&
            (Mathf.Max(L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min(L2.StartPoint.y, L2.EndPoint.y)) &&
            (Mathf.Max(L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min(L1.StartPoint.y, L1.EndPoint.y))
         );
    }
}
