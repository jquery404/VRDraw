using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockTest : MonoBehaviour
{
    // drawing ......
    public bool _startDrawing;
    public bool _brushDown;
    public GameObject linePrefab;

    Line activeLine;
    Vector3 _controllerPosition = Vector3.zero;

    void Update()
    {
        if (_brushDown)
        {
            if(_startDrawing == false)
            {
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<Line>();
                _startDrawing = true;
            }
        } 
        else 
        {
            activeLine = null;
            _startDrawing = false;
        }


        if(activeLine != null)
        {
            _controllerPosition = transform.position;
            activeLine.UpdateLine(_controllerPosition); 
        }
    }
}
