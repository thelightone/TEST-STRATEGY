using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Field : MonoBehaviour
{
    public Vector2Int fieldSize = new Vector2Int(50,50);
    public GameObject gridVisual;
    private House[,] buildings;
    public House blueprint = null;
    private Camera mainCamera;
    private Vector3 curMosPos;
    private bool onButton = true;
    public Buttons button1;
    public Buttons button2;
    public Buttons button3;





    // Start is called before the first frame update
    void Awake()
    {
        buildings = new House[fieldSize.x, fieldSize.y];
        mainCamera= Camera.main;
      

    }

    // Update is called once per frame
    void Update()
    {
       if (blueprint != null)
       {
           
            var plane = new Plane(Vector3.up, Vector3.zero);
            var mouse = Input.mousePosition;
            var point = mainCamera.ScreenPointToRay(mouse);

            if (plane.Raycast(point, out float position))
            {
                Vector3 precisePos = point.GetPoint(position);
                int x = Mathf.RoundToInt(precisePos.x);
                int y = Mathf.RoundToInt(precisePos.z);

                bool freeSpace = true;
              //  blueprint.mainRend.material.color = Color.green;
              blueprint.ChangeColor(Color.green);
              blueprint.transform.position = new Vector3(x, 0, y);
              curMosPos = blueprint.transform.position;

                if (x < 0 || x > fieldSize.x - blueprint.size.x 
                    || y < 0 || y > fieldSize.y - blueprint.size.y
                    || BusySpace(x, y))
                 
                {
                    // blueprint.mainRend.material.color = Color.red;
                    blueprint.ChangeColor(Color.red);
                    freeSpace = false;
                }

                OnButton();

                if (Input.GetMouseButtonDown(0) && freeSpace && !onButton )
                {

                    blueprint.ChangeColor(Color.clear);

                    gridVisual.SetActive(false);

                    for (int i = 0; i < blueprint.size.x; i++)
                    {
                        for (int j = 0; j < blueprint.size.y; j++)
                        {
                            buildings[x + i, y + j] = blueprint;
                        }
                    }
                     blueprint = null;
                    //Destroy(blueprint);
                    // Instantiate(blueprint);
                   // StartCoroutine(Spawn());

                }

            }

        }

    }
    public void ChooseHouse(House house)
    {
        

        if (blueprint != null)
        {
            
            DestroyHouse();// blueprint = null;
         }
       blueprint = Instantiate(house);
       gridVisual.SetActive(true);
       // button.onButton = false;
        
    }

    private bool BusySpace(int spaceX, int spaceY)
    {
        for (int i = 0; i < blueprint.size.x; i++)
        {
            for (int j = 0; j < blueprint.size.y; j++)
            {
                if (buildings[spaceX + i, spaceY + j] != null) return true;
            }
        }
        return false;
    }
    public void DestroyHouse()
    {
        blueprint.Destroy();

    }

    public void OnButton()
    {

        if (button1.isOver || button2.isOver || button3.isOver) onButton = true;
        else onButton = false;
    }
}
