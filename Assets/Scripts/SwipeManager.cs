using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class SwipeManager : MonoBehaviour, IDragHandler
{
    private Transform transforms;
    private float speed;
    private float border;

    private float move;

    void Start()
    {
        speed = 10.0f;
        border = 120.0f;
        move = 5.0f;
        transforms = FindObjectsOfType<CapsuleCollider2D>().FirstOrDefault().transform;
    }


    public void OnDrag(PointerEventData eventData)
    {
        var target = transforms.localPosition;
        if (eventData.delta.x < 0)
        {
            target.x -= move;
        }
        else if (eventData.delta.x > 0)
        {
            target.x += move;
        }
        if (target.x > -border && target.x < border)
        {
            transforms.localPosition = Vector3.Lerp(transforms.localPosition, target, speed * Time.deltaTime);
        }
    }
}
