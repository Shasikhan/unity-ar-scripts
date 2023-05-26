using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    private GameObject[] prefabs;
    private string selectedAlphabet;
    public float spawnPosX = 3.0f;
    public float spawnPosY = 3.0f;
    public float spawnPosZ = 3.0f;

    public TMP_Text totalElementsText;

    // Start is called before the first frame update
    void Start()
    {
        selectedAlphabet = AlphabetSelection.selectedAlphabet;
        PlacePrefabs();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlacePrefabs()
    {
        prefabs = Resources.LoadAll<GameObject>("Prefabs/" + selectedAlphabet);
        Debug.Log("prefabs length: " + prefabs.Length);
        totalElementsText.text = "Total Elements: " + prefabs.Length.ToString();
        // place the A object
        if (prefabs.Length > 0)
        {
            foreach (GameObject prefab in prefabs)
            {

                float xPos = Random.Range(-spawnPosX, spawnPosX);
                float yPos = Random.Range(-spawnPosY, spawnPosY);
                float zPos = Random.Range(-spawnPosZ, spawnPosZ);

                Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

                Instantiate(prefab, spawnPos, Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0));
            }
        }
    }


}
