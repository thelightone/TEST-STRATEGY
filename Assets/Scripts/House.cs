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
       // explosion = GetComponent<ParticleSystem>();
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
            Debug.Log("boom");
            Destroy(gameObject,0.3f);
            gridVisual.SetActive(false);

        }
    }
    public void ChangeColor(Color color)
    {
       // Debug.Log(color);
        mainRend.material.color = color;
    }
    public void Destroy()
    { 
        Debug.Log("Destroy");
       Destroy(gameObject);
}
}


