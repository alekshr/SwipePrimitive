using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class DragManager : MonoBehaviour, IDragHandler//, IBeginDragHandler, IEndDragHandler
{
    private Transform transforms;
    private float speed;

    private float border;

    private Camera mainCamera;

    void Start()
    {
        speed = 2.0f;
        transforms = FindObjectsOfType<CapsuleCollider2D>().FirstOrDefault().transform;
        mainCamera = FindObjectsOfType<Camera>().FirstOrDefault();
        border = 120.0f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var target = transforms.localPosition;
        target.x += pos.x;
        if(target.x > -border && target.x < border)
        {
            transforms.localPosition = Vector3.Lerp(transforms.localPosition, target, speed * Time.deltaTime);
        }
    }

}
