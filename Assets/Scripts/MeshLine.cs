using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshLine : MonoBehaviour
{

    public Material material;

    void Start()
    {
        Mesh mesh = new Mesh();
        GameObject go = new GameObject("MeshLine", typeof(MeshFilter), typeof(MeshRenderer));
        go.transform.localScale = new Vector3(30, 30, 30);
    }

    void Update()
    {
        
    }
}
