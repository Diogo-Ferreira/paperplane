using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class SectionManager : MonoBehaviour
{

    public GameObject sectionPrefab;
    Queue<GameObject> sections;
    public int nbSection;
    Vector3 position;

    private int currentPathIndex = 1;
    private int difficulty = 3;
    private int[] map = null;
    // Use this for initialization
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {

    }

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

    public void CreateSection()
    {

        float h = sectionPrefab.GetComponent<Renderer>().bounds.size.z;

        var obj = Instantiate(sectionPrefab) as GameObject;

        obj.transform.parent = this.gameObject.transform;

        obj.transform.position = position;
        SectionController sectionController = obj.GetComponent<SectionController>() as SectionController;

        if (map == null) map = new int[] { 0, 0, 0, 0, 0, 0 };
        else map = getNewMap(map);
        sectionController.StudentsMap = map;

        sections.Enqueue(obj);
        position.z += h;
    }


    int[] getNewMap(int[] lastMap)
    {

        var firstLine = getLine();
        var secondLine = getLine();
        var finalLine = firstLine.Concat(secondLine).ToArray();
        return finalLine;

    }

    int[] getLine(int n = 3)
    {
        int[] line = randomArray(n);

        currentPathIndex = Mathf.Abs((currentPathIndex + UnityEngine.Random.Range(-1, 1)) % (n - 1));

        line[currentPathIndex] = 0;

        // Checks that we dont fill all the stugens on the line
        if (!line.Any(e => e == 0))
        {
            line[UnityEngine.Random.Range(0, n)] = 0;
        }

        if(line[0] == 1 && line[1] == 1 && line[2] == 1)
        {
            Debug.Log("Noooooooo");
        }

        return line;
    }


    int[] randomArray(int n)
    {
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = System.Convert.ToInt32(UnityEngine.Random.Range(0, 2 * difficulty) != 0);
        }

        return result;
    }

    public void PullTrigger(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(sections.Dequeue());
            CreateSection();
        }

    }

}