using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SectionManager : MonoBehaviour {

    public GameObject sectionPrefab;
    List<GameObject> sections;
    public int nbSection;

	// Use this for initialization
	void Start () {
        sections = new List<GameObject>();

        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (Application.isPlaying)
        {
            CreateBoard(this.nbSection);
        }
        else if (this.transform.childCount == 0)
        {
            CreateBoard(1);
        }


    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}

    void CreateBoard(int nbSection)
    {
        float h = sectionPrefab.GetComponent<Renderer>().bounds.size.z;
        Vector3 position = this.transform.position;

        for(int i = 0; i < nbSection; i++)
        {
            var obj = Instantiate(sectionPrefab) as GameObject;

            obj.transform.parent = this.gameObject.transform;

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
