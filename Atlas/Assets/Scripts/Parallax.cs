using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Canvas canvas;
    Vector3 centerVector;
    Vector3 mouseCenterDisplacement;
    List<Vector3> childrenOriginalPositions;

    private float lerpFactor = 0.01f;
    private float backGroundMove = 0.0005f;
    public float planetsMoveX = 0.006f;
    public float planetsMoveY = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        centerVector = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        childrenOriginalPositions = new List<Vector3>();

        foreach (RectTransform child in transform)
        {
            childrenOriginalPositions.Add(child.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseCenterDisplacement = Input.mousePosition - centerVector;

        int i = 0;
        foreach(RectTransform child in transform)
        {
            if (child.tag == "ParallaxStatic")
            {
                // Do nothing
            }
            else if (child.name == "background")
            {
                child.position = new Vector3(Mathf.Lerp(child.position.x, childrenOriginalPositions[i].x - mouseCenterDisplacement.x * backGroundMove, lerpFactor),
                                             Mathf.Lerp(child.position.y, childrenOriginalPositions[i].y - mouseCenterDisplacement.y * backGroundMove, lerpFactor),
                                             childrenOriginalPositions[i].z);
            }
            else
            {
                child.position = new Vector3(Mathf.Lerp(child.position.x, childrenOriginalPositions[i].x - mouseCenterDisplacement.x * planetsMoveX, lerpFactor),
                                             Mathf.Lerp(child.position.y, childrenOriginalPositions[i].y - mouseCenterDisplacement.y * planetsMoveY, lerpFactor),
                                             childrenOriginalPositions[i].z);
            }
            
            i++;
        }
    }
}
