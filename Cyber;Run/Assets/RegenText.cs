using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenText : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "\tRegen:" + player.regenProgress.ToString() + "/" + player.regenThreshold.ToString();
    }
}
