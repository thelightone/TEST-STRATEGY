using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class House : MonoBehaviour
{
    public Vector2Int size = Vector2Int.one;
    public Renderer mainRend;
    private GameObject gridVisual;
    public ParticleSystem explosion;


    // Start is called before the first frame update
    void Start()
    {
        gridVisual = GameObject.Find("Grid");
       
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            explosion.Play();
           
            Destroy(gameObject,0.3f);
            gridVisual.SetActive(false);

        }
    }
    public void ChangeColor(Color color)
    {
       
        mainRend.material.color = color;
    }
    public void Destroy()
    { 
       
       Destroy(gameObject);
}
}


