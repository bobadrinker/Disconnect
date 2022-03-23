using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;

    public QuestManager theQM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {

    }

    public void EndQuest()
    {
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
