using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
    float MovimentoX;
    float MovimentoY;
    int Direcao;
    public Vector2 Posicao;
    public Vector2 ultimaPosicao;
    Controlador Controlador;
    [SerializeField] GameObject Corpo;
    public GameObject[] TodosCorpos;
    public List<Transform> Corpos = new List<Transform>();
    [SerializeField] Sprite[] movimento;
    [SerializeField] SpriteRenderer render;
    private void Awake()
    {
        Controlador = GameObject.FindGameObjectWithTag("Controlador").GetComponent<Controlador>();
    }
    private void Start()
    {
        Nascer();
    }
    private void Update()
    {
        Trocar();
        TodosCorpos = GameObject.FindGameObjectsWithTag("Corpo");
    }
    private void FixedUpdate()
    {
        ultimaPosicao = transform.position;
        Movimentacao(Direcao);
    }
    void Movimentacao(int Direcao)
    {
        if (Direcao == 1)
        {
            MovimentoX++;
            render.sprite = movimento[0];
        }
        if (Direcao == 2)
        {
            MovimentoX--;
            render.sprite = movimento[1];
        }
        if (Direcao == 3)
        {
            MovimentoY++;
            render.sprite = movimento[2];
        }
        if (Direcao == 4)
        {
            MovimentoY--;
            render.sprite = movimento[3];
        }
        Posicao = new Vector2(MovimentoX, MovimentoY);
        transform.position = Posicao;
    }
    int Trocar()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Corpos.Count == 0)
            {
                return Direcao = 1;
            }
            else
            {
                if (Direcao == 2)
                {
                    return Direcao = 2;
                }
                else
                {
                    return Direcao = 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Corpos.Count == 0)
            {
                return Direcao = 2;
            }
            else
            {
                if (Direcao == 1)
                {
                    return Direcao = 1;
                }
                else
                {
                    return Direcao = 2;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Corpos.Count == 0)
            {
                return Direcao = 3;
            }
            else
            {
                if (Direcao == 4)
                {
                    return Direcao = 4;
                }
                else
                {
                    return Direcao = 3;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Corpos.Count == 0)
            {
                return Direcao = 4;
            }
            else
            {
                if (Direcao == 3)
                {
                    return Direcao = 3;
                }
                else
                {
                    return Direcao = 4;
                }
            }
        }
        return Direcao;
    }
    public int OnTriggerEnter2D(Collider2D quem) 
    {
        if(quem.gameObject.tag == "Parede")
        {
            Morrer();
            return Controlador.pontos = 0;
        }
        if(quem.gameObject.tag == "Comida")
        {
            Crescer();
            Controlador.MoverComida();
            return Controlador.pontos++;
        }
        if (quem.gameObject.tag == "Corpo")
        {
            Morrer();
            return Controlador.pontos = 0;
        }
        return Controlador.pontos;
    }
    void Morrer()
    {
        MovimentoX = 0;
        MovimentoY = 0;
        transform.position = new Vector2(MovimentoX, MovimentoY);
        Direcao = 1;       
        Controlador.MoverComida();
        Controlador.ContabilizarPontos();
        Corpos.Clear(); 
        foreach(GameObject corpo in TodosCorpos)
        {
            Destroy(corpo);
        }
    }
    void Crescer()
    {
        Instantiate(Corpo);
        Corpos.Add(Corpo.transform);     
    }
    void Nascer()
    {
        Direcao = 1;
        Controlador.MoverComida();
    }
}
