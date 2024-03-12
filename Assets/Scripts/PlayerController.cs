using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidade do jogador
    public Animator animator; // Refer�ncia para o Animator
    private Vector3 lastDirection; // �ltima dire��o do jogador

    // Update � chamado uma vez por frame
    void Update()
    {
        // Obtendo a entrada do teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculando o movimento do jogador
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed * Time.deltaTime;

        // Verificando se houve mudan�a de dire��o
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            lastDirection = movement.normalized;
        }

        // Rotacionando o jogador para a dire��o desejada
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lastDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Aplicando o movimento ao jogador
        transform.Translate(movement, Space.World);

        // Atualizando a condi��o 'isMoving' do Animator
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
        }

        // Mantendo o jogador dentro dos limites da tela (opcional)
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -80f, 80f); // Limitando o movimento horizontal
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -40.5f, 40.5f); // Limitando o movimento vertical
        transform.position = clampedPosition;
    }
}