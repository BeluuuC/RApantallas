using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Para TextMeshPro, si usas UI Text, cambia a 'using UnityEngine.UI;'

public class TextoClickeable : MonoBehaviour
{
    public TMP_Text miTexto;        // Arrastra aquí tu TextMeshPro
    public int trabajosCompletados; // Cambia este número según corresponda
    public string nombreEscena = "insg"; // Escena a cargar

    void Start()
    {
        // Actualiza el texto al iniciar
        miTexto.text = "Completaste " + trabajosCompletados + " de Trabajos Auxiliares";
    }

    // Esta función se llama al hacer clic en el texto
    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
