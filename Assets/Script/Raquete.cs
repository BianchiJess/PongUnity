using UnityEngine;
using UnityEngine.InputSystem;

public class Raquete : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float speed = 5f; //Velocidade Raquete
    [SerializeField] private float limitY = 3.7f; //Limite Raquete no eixo Y

    private float myY; //Posição atual no eixo Y da Raquete

    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Start()
    {
        myY = transform.position.y; //Pegar posição Y
    }

    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        myY += input.y * speed * Time.deltaTime; //Ganho de velocidade
        myY = Mathf.Clamp(myY, -limitY, limitY); //Limite de onde a Raquete pode chegar

        //Movimentação -- É um bubble sort
        Vector3 pos = transform.position; //Pega a posição atual
        pos.y = myY; //Atribui a nova posição
        transform.position = pos; //Move a Raquete para a nova posição

    }
}
