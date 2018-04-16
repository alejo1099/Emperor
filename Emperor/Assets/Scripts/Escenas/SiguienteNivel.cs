using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{
    public int nivelSiguiente;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            SceneManager.LoadScene(nivelSiguiente);
    }
}
