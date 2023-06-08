using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class Field : MonoBehaviour
{
    private Vector2Int _fieldSize = new Vector2Int(50, 50);
    private House[,] _buildings;
    private Camera _mainCamera;
    private Vector3 _mousePos;

    [SerializeField]
    private GameObject _gridVisual;
    [SerializeField]
    private House _blueprint;

    void Awake()
    {
        _buildings = new House[_fieldSize.x, _fieldSize.y];
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (_blueprint != null && (Input.GetMouseButtonDown(0) || _mousePos != Input.mousePosition))
        {
            var plane = new Plane(Vector3.up, Vector3.zero);
            _mousePos = Input.mousePosition;
            var point = _mainCamera.ScreenPointToRay(_mousePos);

            if (plane.Raycast(point, out float position))
            {
                int x, y;
                bool freeSpace;

                _FindMousePos(point, position, out x, out y, out freeSpace);
                freeSpace = _CheckFree(x, y, freeSpace);
                _CreateBuilding(x, y, freeSpace);
            }

        }

    }

    private void _FindMousePos(Ray point, float position, out int x, out int y, out bool freeSpace)
    {
        Vector3 precisePos = point.GetPoint(position);
        x = Mathf.RoundToInt(precisePos.x);
        y = Mathf.RoundToInt(precisePos.z);

        freeSpace = true;

        _blueprint.ChangeColor(Color.green);
        _blueprint.transform.position = new Vector3(x, 0, y);
    }

    private bool _CheckFree(int x, int y, bool freeSpace)
    {
        if (
            x < 0 || x > _fieldSize.x - _blueprint.size.x
            || y < 0 || y > _fieldSize.y - _blueprint.size.y
            || _BusySpace(x, y)
            )
        {
            _blueprint.ChangeColor(Color.red);
            freeSpace = false;
        }
        return freeSpace;
    }

    private void _CreateBuilding(int x, int y, bool freeSpace)
    {
        if (Input.GetMouseButtonDown(0) && freeSpace && !EventSystem.current.IsPointerOverGameObject())
        {
            _blueprint.ChangeColor(Color.clear);
            _gridVisual.SetActive(false);
            for (int i = 0; i < _blueprint.size.x; i++)
            {
                for (int j = 0; j < _blueprint.size.y; j++)
                {
                    _buildings[x + i, y + j] = _blueprint;
                }
            }
            _blueprint = null;
        }
    }

    private bool _BusySpace(int spaceX, int spaceY)
    {
        for (int i = 0; i < _blueprint.size.x; i++)
        {
            for (int j = 0; j < _blueprint.size.y; j++)
            {
                if (_buildings[spaceX + i, spaceY + j] != null) return true;
            }
        }
        return false;
    }

    public void ChooseHouse(House house)
    {
        if (_blueprint != null)
        {
            DestroyHouse();
        }
        _blueprint = Instantiate(house);
        _gridVisual.SetActive(true);
    }

    public void DestroyHouse()
    {
        _blueprint.Destroy();
    }

}
