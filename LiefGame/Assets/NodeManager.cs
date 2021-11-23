using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NodeManager : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [SerializeField]
    LeafGameManager gameManager;

    [SerializeField]
    private string nodeNameToWin;
    [SerializeField]
    private string nodeNameToLose;


    // Start is called before the first frame update
    private void OnEnable()
    {
        if(dialogueRunner != null)
        {
            dialogueRunner.onNodeComplete.AddListener(CheckNode_CodeListener);
        }
    }

    private void OnDisable()
    {
        dialogueRunner.onNodeComplete.RemoveListener(CheckNode_CodeListener);

    }

    private void CheckNode_CodeListener(string _nodeName)
    {
        if(_nodeName == nodeNameToWin)
        {
            Debug.Log("YOU WIN");
            gameManager.winGame();
        }

        if(_nodeName == nodeNameToLose)
        {
            Debug.Log("YouLose");
            gameManager.loseGame();
        }
    }
}
