using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject[] objetos; // Arreglo de objetos que se mover�n
    public float velocidad = 5f; // Velocidad de movimiento en unidades por segundo
    private Vector3[] direcciones; // Direcciones de movimiento para cada objeto

    void Start()
    {
        direcciones = new Vector3[objetos.Length];
        
        // Asignar direcciones aleatorias o personalizadas a cada objeto
        for (int i = 0; i < objetos.Length; i++)
        {
            // Puedes personalizar la direcci�n para cada objeto aqu�
            // Ejemplo: Movimiento aleatorio (puedes personalizarlo seg�n tu necesidad)
            direcciones[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        }
    }

    void Update()
    {
        // Mover cada objeto
        for (int i = 0; i < objetos.Length; i++)
        {
            // Mover el objeto en funci�n del tiempo transcurrido y la direcci�n asignada
            objetos[i].transform.Translate(direcciones[i] * velocidad * Time.deltaTime);

            // Si el objeto sale de la pantalla, vuelve a entrar desde el borde opuesto
            if (objetos[i].transform.position.x > Screen.width || objetos[i].transform.position.x < 0 ||
                objetos[i].transform.position.y > Screen.height || objetos[i].transform.position.y < 0)
            {
                // Reposicionar el objeto en una posici�n aleatoria dentro de la pantalla
                objetos[i].transform.position = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 0f);
            }
        }
    }
}
