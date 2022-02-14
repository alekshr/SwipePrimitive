using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
class KeyboardManager : MonoBehaviour
{

    private Transform transforms;
    private float speed;

    private float border;

    private float move;


    void Start()
    {
        speed = 10.0f;
        border  = 120.0f;
        move = 5.0f;
        transforms = FindObjectsOfType<CapsuleCollider2D>().FirstOrDefault().transform;
    }

    void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        var target = transforms.localPosition;
        if (horizontalValue < 0)
        {
            target.x -= move;
        }
        else if (horizontalValue > 0)
        {
            target.x += move;
        }
        if (target.x > -border && target.x < border)
        {
            transforms.localPosition = Vector3.Lerp(transforms.localPosition, target, speed * Time.deltaTime);
        }
        //transforms.localPosition = Vector3.Lerp(transforms.localPosition, target, speed * Time.deltaTime);

    }
}
