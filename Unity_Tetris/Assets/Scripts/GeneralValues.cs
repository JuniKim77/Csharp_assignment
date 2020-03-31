using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralValues : MonoBehaviour
{
    public int gameType { get; set; }
    public int difficulty { get; set; }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()




    {
        DontDestroyOnLoad(this);
    }
}
