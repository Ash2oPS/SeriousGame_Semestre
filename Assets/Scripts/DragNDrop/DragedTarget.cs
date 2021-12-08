using UnityEngine;
using UnityEngine.UI;

public class DragedTarget : MonoBehaviour
{
    public string itemName;

    public void IsDragedOn(DragAndDrop objectDraged)
    {
        objectDraged.rt.position = ((RectTransform)transform).position;
        var item = objectDraged.GetComponent<DragedTarget>();
        print("vous venez de combiner " + itemName + " avec " + item.itemName);
        Destroy(objectDraged.gameObject);
        Destroy(gameObject);
    }
}
