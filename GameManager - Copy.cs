using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScriptableObject.CreateInstance<PlayerScriptable>();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
