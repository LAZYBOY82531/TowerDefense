using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDrag: MonoBehaviour
{
	[SerializeField] private RectTransform dragRectangle;
	private	Rect dragRect;
	private	Vector2 start = Vector2.zero;
	private	Vector2 end = Vector2.zero;	
	public	Camera mainCamera;
	public	RTSUnitController rtsUnitController;
	private bool ispressed;

	private void Awake()
	{
		mainCamera = Camera.main;
		rtsUnitController = GetComponent<RTSUnitController>();
		DrawDragRectangle();
	}

	private void OnLeftButton(InputValue value)
	{
		if (value.isPressed)
        {
            ispressed = true;
            start = Input.mousePosition;
            dragRect = new Rect();
        }

		if (!value.isPressed)
        {
            ispressed = false;
            CalculateDragRect();
            SelectUnits();
            start = end = Vector2.zero;
            DrawDragRectangle();
        }
    }

	private void OnLeftDrag(InputValue value)
    {
		if (ispressed)
        {
            end = Input.mousePosition;
            DrawDragRectangle();
        }
    }

	private void DrawDragRectangle()
	{
		dragRectangle.position = (start + end) * 0.5f;
		dragRectangle.sizeDelta	= new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
	}

	private void CalculateDragRect()
	{
		if ( Input.mousePosition.x < start.x )
		{
			dragRect.xMin = Input.mousePosition.x;
			dragRect.xMax = start.x;
		}
		else
		{
			dragRect.xMin = start.x;
			dragRect.xMax = Input.mousePosition.x;
		}

		if ( Input.mousePosition.y < start.y )
		{
			dragRect.yMin = Input.mousePosition.y;
			dragRect.yMax = start.y;
		}
		else
		{
			dragRect.yMin = start.y;
			dragRect.yMax = Input.mousePosition.y;
		}
	}

	private void SelectUnits()
	{
		foreach ( UnitController unit in rtsUnitController.UnitList )
		{
			if ( dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)) )
			{
				rtsUnitController.DragSelectUnit(unit);
			}
		}
	}
}

