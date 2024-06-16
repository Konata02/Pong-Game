using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    
    void Start(){
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();
        string points = SaveController.Instance.GetPoints();
        
        

        if (lastWinner != "") uiWinner.text = "Último vencedor: " + lastWinner + " " + "Pontos: " + points;
        else uiWinner.text = "";

        Debug.Log("A pontuação atual é:  X@ " + points);
    }

}
