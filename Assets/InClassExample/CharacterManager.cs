using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    /*
    This Class will control which character are in play
    This class is also an example for the class about how to get a reference from one game object all the way over to anothr game object
    */

    public GameObject Alexa;
    public GameObject Bonnie;
    public GameObject Carly;
    public GameObject Dave;
    public GameObject Eric;
    public GameObject Fiona;

    public GameObject PlayerOne_GO;
    public GameObject PlayerTwo_GO;


    public void Update()
    {
        // Do a Null Check 
        // This means we only print if PlayerOne_GO is not null
        // != means "not equal to"
        // null means you need to create a reference to give your variable a value
        // gameObject is a reference type of variable
        // int, float, bool these are all value types and value types come with default values: bool is false and int is 0 when you declare them 
        
        if (PlayerOne_GO != null) // 
        {
            // PlayerOne_GO is null until ChooseCharacter.OnMouseDown() is called
            print(PlayerOne_GO.name +"  In the Update() in CharacterManager");
        }
    }

}
