using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Refer�ncia ao jogador
    public float offsetX = 0f; // Offset em X
    public float offsetY = 5f; // Offset em Y
    public float offsetZ = 0f; // Offset em Z

    // Update � chamado uma vez por frame
    void FixedUpdate()
    {
        // Verificando se a refer�ncia ao jogador est� definida
        if (player != null)
        {
            // Obtendo a posi��o atual da c�mera
            Vector3 newPosition = transform.position;

            // Ajustando a posi��o da c�mera para coincidir com a posi��o do jogador, com offsets personalizados
            newPosition.x = player.position.x + offsetX;
            newPosition.y = player.position.y + offsetY;
            newPosition.z = player.position.z + offsetZ;

            // Aplicando a nova posi��o � c�mera
            transform.position = newPosition;
        }
    }
}
