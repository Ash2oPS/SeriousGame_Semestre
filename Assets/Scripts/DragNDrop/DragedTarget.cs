using UnityEngine;
using UnityEngine.UI;

public class DragedTarget : MonoBehaviour
{
    public void IsDragedOn(DragAndDrop objectDraged)
    {
        print(objectDraged.name);
        objectDraged.rt.position = ((RectTransform)transform).position;
        var image = objectDraged.GetComponent<Image>();
        image.color = new Color (image.color.r, image.color.g,image.color.b, 0.5f);

    }
}
