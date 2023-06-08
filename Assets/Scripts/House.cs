using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class House : MonoBehaviour
{
    private GameObject _gridVisual;
    private AudioSource _source;

    [SerializeField]
    private Renderer _mainRend;
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private AudioClip _death;

    public Vector2Int size = Vector2Int.one;

    void Start()
    {
        _gridVisual = GameObject.Find("Grid");
        _source = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _explosion.Play();
            _source.PlayOneShot(_death);
            Destroy(gameObject, 0.3f);
            _gridVisual.SetActive(false);
        }
    }

    public void ChangeColor(Color color)
    {
        _mainRend.material.color = color;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}


