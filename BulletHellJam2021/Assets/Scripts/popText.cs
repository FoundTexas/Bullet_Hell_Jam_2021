using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popText : MonoBehaviour
{
    public float LifeTime;
    Vector2 Direction;
    public float Speed;

    private void Start()
    {
        Invoke("Destroy", LifeTime);
        Direction = Vector2.up;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }
}
