using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RelojScript : MonoBehaviour
{
    [SerializeField] private ClockData clockData;
    public TextMeshProUGUI tiempoTexto;
    public Image relojImagen;

    public float tiempoTotal = 3600f;
    private float tiempoRestante;
    private bool relojIniciado = false; // <-- nuevo flag


    void Start()
    {
        Scene escenaActual = SceneManager.GetActiveScene();

        if (escenaActual.name == "Jurar" && !clockData.yaInicio)
        {
            clockData.yaInicio = true;
            InitReloj();
        }
        else
        {
            // Si ya había iniciado, seguimos donde lo dejó
            tiempoRestante = clockData.timeClock;
            relojIniciado = true;
        }
    }

    void Update()
    {
        // No hacemos nada hasta que esté iniciado
        if (!relojIniciado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
        }

        clockData.timeClock = tiempoRestante;
        ActualizarReloj();
    }

    void InitReloj()
    {
        tiempoRestante = clockData.timeClock > 0 ? clockData.timeClock : tiempoTotal;
        relojIniciado = true;
        ActualizarReloj();
    }

    void ActualizarReloj()
    {
        relojImagen.fillAmount = Mathf.Clamp01(tiempoRestante / tiempoTotal);

        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        tiempoTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}