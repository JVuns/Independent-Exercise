using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGUIScript : MonoBehaviour
{
	[SerializeField]
	private GameObject player;
	private float hp;
	private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "HP: ";
    }

    // Update is called once per frame
    void Update()
    {
        hp = (int)hp;
        text.text = "HP: " + hp;
    }
}
