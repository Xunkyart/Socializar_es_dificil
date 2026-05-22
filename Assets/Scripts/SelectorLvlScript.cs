using UnityEngine;

public class SelectorLvlScript : MonoBehaviour
{
     public GameObject[] levels;
    private int currentLevel = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowLevel();

    }

    // Update is called once per frame
    void Update()
    {

    }

public void NextLevel()
    {
        currentLevel++;

        if (currentLevel >= levels.Length)
        {
            currentLevel = 0; // vuelve al primero
        }

        ShowLevel();
    }

     public void PreviousLevel()
    {
        currentLevel--;

        if (currentLevel < 0)
        {
            currentLevel = levels.Length - 1; // va al último
        }

        ShowLevel();
    }

    void ShowLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == currentLevel);
        }
    }
    


}
