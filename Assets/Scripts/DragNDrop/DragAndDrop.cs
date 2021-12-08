using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class DragAndDrop : Button
{
    public RectTransform rt;
    public Vector2Int grid;
    public GraphicRaycaster gr;
    private bool isDrag;


    public override void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Vector3 _gridPosition = Input.mousePosition - new Vector3(Input.mousePosition.x % grid.x, Input.mousePosition.y % grid.y, 0);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            var resultAsTarget = result.gameObject.GetComponent<DragedTarget>();
            if(resultAsTarget && resultAsTarget.gameObject != gameObject)
            {
                resultAsTarget.IsDragedOn(this);
            }
        }


        isDrag = false;
    }
    public void Update()
    {   
        if(isDrag)
        {
            Vector3 _gridPosition = Input.mousePosition - new Vector3(Input.mousePosition.x % grid.x, Input.mousePosition.y % grid.y, 0);
            rt.position = _gridPosition;
        }
    }
}
