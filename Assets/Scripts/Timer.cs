using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timer = 180f;
    bool tempoesgotado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer = Time.deltaTime;
            Debug.Log("Tempo restante: " + Mathf.Ceil(timer) + " segundos");
        }
        else if (tempoesgotado)
        {
            tempoesgotado = true;
            timer = 0;
            Derrota();
        }
        void Derrota()
        {
            Debug.Log("Tempo esgotado! Você perdeu!");

        }
    }
}


