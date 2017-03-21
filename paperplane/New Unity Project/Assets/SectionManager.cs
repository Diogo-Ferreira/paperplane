using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {

    public GameObject sectionPrefab;
    List<GameObject> sections;
    public int nbSection;

	// Use this for initialization
	void Start () {
        sections = new List<GameObject>();
        CreateBoard();	
	}

    void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}

    void CreateBoard()
    {
        float h = sectionPrefab.GetComponent<Renderer>().bounds.size.z;
        Vector3 position = this.transform.position;

        for(int i = 0; i < nbSection; i++)
        {
            var obj = Instantiate(sectionPrefab) as GameObject;

            obj.transform.position = position;
            SectionController sectionController = obj.GetComponent<SectionController>() as SectionController;
            sectionController.StudentsMap = randomArray();

            sections.Add(obj);
            position.z += h;
        }
    }

    int[] randomArray()
    {
        int[] result = new int[6];
        for(int i = 0; i < 6; i++)
        {
            result[i] = Random.Range(0, 2);
        }

        return result;
    }
}
