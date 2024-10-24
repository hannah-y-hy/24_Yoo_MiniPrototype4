using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    /*
        This class is for letting player's choose their characters
        Player's will click on their choice

        This class will use te OnMouseDown() method 
        https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html

        OnMouseDown() will be called when someone clicks on the attached gameobject, if the GO has a collider on it!
    */


    public GameObject CharacterManagerGO;
    public CharacterManager TheCharacterManager;


    public void OnMouseDown() 
    {
        // print("This is the GO that was clickrd on:  "+ gameObject.name);

        // When chosen by player, assign this GO to the CharacterManager.cs as PlayerOne
        // I need a reference to CharacterManager script!
        // CAN MANKE REFERENCE IN UNITY EDITOR
        // or use this Findbytag
        CharacterManagerGO = GameObject.FindGameObjectWithTag("GameController");

        TheCharacterManager = CharacterManagerGO.GetComponent<CharacterManager>();
        
        // Assigning a value to a variable in the CharacterManager instance
        TheCharacterManager.PlayerOne_GO = gameObject;

        print(TheCharacterManager.PlayerOne_GO +"  In the OnMouseDown() in ChooseCharacter");

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
