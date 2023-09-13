using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private Vector3 objetive;

    [SerializeField] private Camera followCamera;

    private void Update()
    {
        if (Time.timeScale == 1f)
        {
            objetive = followCamera.ScreenToWorldPoint(Input.mousePosition);

            float angRad = Mathf.Atan2(objetive.y - transform.position.y, objetive.x - transform.position.x);

            float angGrad = (180 / Mathf.PI) * angRad - 90;

            transform.rotation = Quaternion.Euler(0, 0, angGrad);
        }
    }
}
