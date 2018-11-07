using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition1 : MonoBehaviour {

    public GameObject[] shutters;
    public Vector3[] start_positions;
    public Vector3[] end_positions;



    int m_cnt;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        ++m_cnt;

        for (int i = 0; i < 2; ++i)
        {
            float t = m_cnt / 60.0f;
            t = t > 1 ? 1 : t;
            Vector3 pos=Vector3.Lerp(start_positions[i], end_positions[i], EaseBounce::Out(t));
            m_shutter[i].setPosition(pos);
        }

        if (m_cnt == 90)
        {
            std::cout << "t" << std::endl;
            machine.pop();
        }
        */
    }
}
