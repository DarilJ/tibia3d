using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float offsetX = 0f; // Offset em X
    public float offsetY = 5f; // Offset em Y
    public float offsetZ = 0f; // Offset em Z

    // Update é chamado uma vez por frame
    void FixedUpdate()
    {
        // Verificando se a referência ao jogador está definida
        if (player != null)
        {
            // Obtendo a posição atual da câmera
            Vector3 newPosition = transform.position;

            // Ajustando a posição da câmera para coincidir com a posição do jogador, com offsets personalizados
            newPosition.x = player.position.x + offsetX;
            newPosition.y = player.position.y + offsetY;
            newPosition.z = player.position.z + offsetZ;

            // Aplicando a nova posição à câmera
            transform.position = newPosition;
        }
    }
}
