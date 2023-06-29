using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClick : MonoBehaviour
{
	[SerializeField] private LayerMask layerUnit;
	[SerializeField] private LayerMask layerGround;
	private	Camera mainCamera;
	private	RTSUnitController rtsUnitController;
	public Vector3 hitpoint;

	private void Awake()
	{
		mainCamera = Camera.main;
		rtsUnitController = GetComponent<RTSUnitController>();
	}

	private void OnLeftButtonPush (InputValue value)
	{
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit))
        {
            if (hit.transform.GetComponent<UnitController>() == null) return;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rtsUnitController.ShiftClickSelectUnit(hit.transform.GetComponent<UnitController>());
            }
            else
            {
                rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                rtsUnitController.DeselectAll();
            }
        }
    }
    private void OnRightButtonPush(InputValue value)
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
        {
            hitpoint = hit.point;
            rtsUnitController.MoveSelectedUnits(hitpoint);
        }
    }
}

