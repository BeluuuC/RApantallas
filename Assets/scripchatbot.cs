using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class APIClient : MonoBehaviour
{
    void Start()
    {
        // Inicia la corutina para enviar un POST con el mensaje "hola"
        StartCoroutine(PostRequest("http://localhost:5005/webhooks/rest/webhook", "hola"));
    }

    IEnumerator PostRequest(string uri, string mensaje)
    {
        // Datos que se mandan al servidor
        var data = new
        {
            sender = "Usuario",
            message = mensaje
        };

        string jsonData = JsonUtility.ToJson(data);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("📤 Enviando a " + uri + " datos: " + jsonData);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Error: " + webRequest.error);
        }
        else
        {
            Debug.Log("📥 Respuesta: " + webRequest.downloadHandler.text);
        }
    }
}
