using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
     private Rigidbody2D rb;
     public float speed = 5f;
     private GameObject ball;
     public Vector2 limits = new Vector2(-4.5f, 4.5f);
     public string movementAxisName = "Vertical";
     public bool isPlayer = true;
     public SpriteRenderer spriteRenderer;
     


    void Start(){
         if (isPlayer) spriteRenderer.color = SaveController.Instance.colorPlayer;
         
         else spriteRenderer.color = SaveController.Instance.colorEnemy;
    }


    void Update(){
        
        float moveInput = Input.GetAxis(movementAxisName);
        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        // Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, limits.x, limits.y);
        // Atualiza a posição da raquete
        transform.position = newPosition;
    }

}
