using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TopDownCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // El objeto que seguirá la cámara
    public float height = 10f; // Altura de la cámara
    public float distance = 2f; // Distancia de la cámara
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la rotación basada en la entrada del usuario
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

            // Calcula la posición de la cámara basada en la posición del objetivo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Interpola suavemente la posición actual de la cámara hacia la posición deseada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);

            // Asegura que la cámara siempre mire hacia el objetivo
            transform.LookAt(target.position);
        }
    }
}
