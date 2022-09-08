using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300.0f;
    [SerializeField] float normalSpeed = 20.0f;
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    int hitCount = 0;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            hitCount--;
            Debug.Log("Boost");
            if (hitCount < 0)
            {
                moveSpeed = boostSpeed;
                hitCount = -1;
                Debug.Log(hitCount);
            }
            if (hitCount == 0)
            {
                moveSpeed = normalSpeed;
                Debug.Log(hitCount);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount++;
        Debug.Log("hit");
        if (hitCount > 0)
        {
            moveSpeed = slowSpeed;
            hitCount = 1;
            Debug.Log(hitCount);
        }
        if (hitCount == 0)
        {
            moveSpeed = normalSpeed;
            Debug.Log(hitCount);
        }
    }
}
