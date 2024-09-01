using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpo : MonoBehaviour
{
    Cobra Cobra;
    [SerializeField]int Index;
    bool podeMover;
    private void Start()
    {
        Cobra = GameObject.FindGameObjectWithTag("Cobra").GetComponent<Cobra>();
        Nascer();   

    }
    private void FixedUpdate()
    {
        Seguir(podeMover);
        TrocarIndex();
    }
    void Nascer()
    {        
        Index = Cobra.Corpos.Count - 1;
        gameObject.name = Cobra.Corpos.Count.ToString();
        this.transform.position = Cobra.transform.position;
    }
    void Seguir(bool podeMover)
    {
        if (podeMover)
            this.transform.position = Cobra.ultimaPosicao;
    }
    bool TrocarIndex()
    {
        if(Index == 0){
            Index = Cobra.Corpos.Count - 1;
            return podeMover = true;
        }
        else{
            Index = Index - 1;
            return podeMover = false;
        }
    }
}
