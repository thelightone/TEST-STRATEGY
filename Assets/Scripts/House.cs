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
    private AudioSource aus;
    public AudioClip death;



    // Start is called before the first frame update
    void Start()
    {
        gridVisual = GameObject.Find("Grid");
        aus = GetComponent<AudioSource>();

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
            aus.PlayOneShot(death);
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


