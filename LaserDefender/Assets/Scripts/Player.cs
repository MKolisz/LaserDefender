using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y - padding;
    }

    private void Move()
    {
        //Time.deltaTime makes movement framerate independent
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPosition = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);
        transform.position = new Vector2(newXPosition, newYPosition);
    }
}
