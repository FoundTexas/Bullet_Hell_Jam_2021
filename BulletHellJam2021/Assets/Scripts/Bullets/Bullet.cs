using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;
    public float LifeTime;
    Vector2 Direction;
    public float Speed;

    private void OnEnable()
    {
        Invoke("Destroy", LifeTime);
    }
    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
