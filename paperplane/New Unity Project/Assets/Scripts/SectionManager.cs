using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SectionManager : MonoBehaviour
{

    public GameObject sectionPrefab;
    Queue<GameObject> sections;
    public int nbSection;
    Vector3 position;

    float timeToGo;

    // Use this for initialization
    void Start()
    {
        timeToGo = Time.fixedTime + 0.2f;
        sections = new Queue<GameObject>();

        foreach (Transform child in this.transform)
        {
            GameObject.DestroyImmediate(child.gameObject);
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

    void FixedUpdate()
    {
        if (Time.fixedTime >= timeToGo)
        {
            DestroyImmediate(sections.Dequeue());
            CreateSection();
            // Do your thang
            timeToGo = Time.fixedTime + 0.2f;
        }
    }

    // Update is called once per frame
    //void Update ()
    //{

    //}

    void CreateBoard(int nbSection)
    {

        position = this.transform.position;

        for (int i = 0; i < nbSection; i++)
        {
            CreateSection();
        }
    }

    int[] RandomArray()
    {
        int[] result = new int[6];
        for (int i = 0; i < 6; i++)
        {
            result[i] = Random.Range(0, 2);
        }

        return result;
    }

    void CreateSection()
    {
        float h = sectionPrefab.GetComponent<Renderer>().bounds.size.z;

        var obj = Instantiate(sectionPrefab) as GameObject;

        obj.transform.parent = this.gameObject.transform;

        obj.transform.position = position;
        SectionController sectionController = obj.GetComponent<SectionController>() as SectionController;
        sectionController.StudentsMap = RandomArray();

        sections.Enqueue(obj);
        position.z += h;
    }
}
