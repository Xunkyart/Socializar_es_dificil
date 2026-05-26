using UnityEngine;

public class SelectorLvlScript : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] start;
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

    // Para que funcionen las Flechitas
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

    // Para que se vea solo el nivel que toca
    void ShowLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == currentLevel); // muestra solo el nivel que toca
            start[i].SetActive(i == currentLevel); // muestra solo el botón de start que toca
        }
    }
    


}