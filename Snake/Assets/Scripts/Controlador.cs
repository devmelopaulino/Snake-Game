using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controlador : MonoBehaviour
{
    GameObject Comida;
    public int pontos;
    public int melhor;
    [SerializeField] TextMeshProUGUI Pontuacao;
    [SerializeField] TextMeshProUGUI MelhorPontuacao;
    Cobra Cobra;
    [SerializeField] GameObject[] Corpos;
    void Awake()
    {  
        Comida = GameObject.FindGameObjectWithTag("Comida");
        Cobra = GameObject.FindGameObjectWithTag("Cobra").GetComponent<Cobra>();
        
    }
    public void Update()
    {
        Pontuacao.text = "SCORE: " + pontos.ToString();
        MelhorPontuacao.text = "BEST: " + melhor.ToString();
        Corpos = GameObject.FindGameObjectsWithTag("Corpo");
        CompararComida();
    }
    public void MoverComida()
    {
        Vector2 Sorteado = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        Comida.transform.position = Sorteado;
    }
    void CompararComida()
    {
        foreach(GameObject ocupado in Corpos)
        { 
            if(Comida.transform.position == ocupado.transform.position)
            {
                MoverComida();
            }
        
        }
    }
    public void ContabilizarPontos()
    {
        if (pontos > melhor)
            melhor = pontos;
    }
}
