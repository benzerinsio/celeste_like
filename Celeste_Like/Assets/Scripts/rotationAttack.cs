using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationAttack : MonoBehaviour
{
    public float rotateSpeed = 0f;
    public float transformDefaultZ = 0f;
    public float positionZ = 0f;
    [SerializeField] Player_Life die;

    private void Start()
    {
        Quaternion initialRotation = Quaternion.Euler(0, 0, transformDefaultZ);
        transform.rotation = initialRotation;
    }
    private void Update()
    {
        // Captura a rota��o atual
        Quaternion currentRotation = transform.rotation;

        // Calcula a nova rota��o aplicando uma rota��o em torno do eixo Z
        Quaternion newRotation = Quaternion.Euler(0, 0, rotateSpeed * Time.deltaTime) * currentRotation;

        // Aplica a nova rota��o ao GameObject
        transform.rotation = newRotation;
    }

    public void resetRotation()
    {
        Quaternion initialRotation = Quaternion.Euler(0, 0, transformDefaultZ);
        transform.rotation = initialRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die.dieHandler();
        }
    }
}
