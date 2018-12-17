
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public List<GameObject> Players;
    public List<GameObject> Enemys;
    public List<GameObject> Electrics;

    public GameObject obj;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }
	}

    public void JoinObjectManager(ref GameObject o,string type)
    {
        switch (type)
        {
            case "Player":
                Players.Add(o);
                break;
            case "Enemy":
                Enemys.Add(o);
                break;
            case "Electrics":
                Electrics.Add(o);
                break;
            default:
                break;
        }
    }
}
