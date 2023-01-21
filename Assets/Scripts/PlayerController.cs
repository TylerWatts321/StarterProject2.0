using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static Transform playerTransform;
    [SerializeField]
    private LineRenderer lineRenderer;

    private void Awake()
    {
        playerTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLaser();
        LookAt();
    }

    private void DrawLaser()
    {
        lineRenderer.SetPosition(0, transform.GetChild(0).TransformPoint(transform.position));
        lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            if(hit)
            {
                TargetController zombie = hit.transform.gameObject.GetComponent<TargetController>();
                zombie.Hit();
                TargetSpawner.instance.RemoveTarget(hit.transform.gameObject);
            }
        }
    }

    private void LookAt()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}
