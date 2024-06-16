using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer;
    public string nameEnemy;
    public string points = "SavedPoints";
    //public string pointsPlayer;

    private static SaveController _instance;
// Propriedade est�tica para acessar a inst�ncia
     
    public static SaveController Instance{
         get{
             if (_instance == null){
                 // Procure a inst�ncia na cena
                 _instance = FindObjectOfType<SaveController>();
                 // Se n�o encontrar, crie uma nova inst�ncia
            
                 if (_instance == null){
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
             }
             return _instance;
          }
     }

     public void Reset(){
         nameEnemy = "";
         namePlayer = "";
         colorEnemy = Color.white;
         colorPlayer = Color.white;
         //pointsEnemy = "";
         //pointsPlayer = "";

     }


     private void Awake(){
             // Garanta que apenas uma inst�ncia do Singleton exista
             if (_instance != null && _instance != this){
                    Destroy(this.gameObject);
                    return;
             }
            // Mantenha o Singleton vivo entre as cenas
            DontDestroyOnLoad(this.gameObject);
     }

     public string GetName(bool isPlayer){
            return isPlayer ? namePlayer : nameEnemy;
     }

     public void SavePoints(string pointsx){
        PlayerPrefs.SetString(points, pointsx);
     }
     
     public string GetPoints(){
            Debug.Log("GetPoints: " + PlayerPrefs.GetString(points));
            return PlayerPrefs.GetString(points);
     }

     public void SaveWinner(string winner){
        PlayerPrefs.SetString("SavedWinner", winner);
     }
     
     public string GetLastWinner(){
        return PlayerPrefs.GetString("SavedWinner");
     }

     public void ClearSave(){
         PlayerPrefs.DeleteAll();
    }





}