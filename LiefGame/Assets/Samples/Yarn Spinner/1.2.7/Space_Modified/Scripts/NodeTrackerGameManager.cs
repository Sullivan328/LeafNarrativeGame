using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NodeTrackerGameManager : MonoBehaviour
{
    [TextArea(10,20)]
    [SerializeField]
    private string notes;
    [Space(10)]
    [SerializeField]
    private DialogueRunner m_dialogueRunner;

    //These strings are the node names to watch for
    [SerializeField]
    private string nodeNameToWin;
    [SerializeField]
    private string nodeNameToLose;



    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //These functions handle adding a listener to the "OnNodeComplete" UnityEvent in the DialogueRunner.cs script
    //When this object is enabled, we'll start listening for a message from the "OnNodeComplete" event.
    //When the event is invoked, we'll get a message and call the method "CheckNode_CodeListener"

    private void OnEnable()
    {
        if (m_dialogueRunner != null)
        {
           //The Unity Event "OnNodeComplete" is a custom type of UnityEvent
           //Unity Events don't inherently send data, only a message that something has happened.
           //Yarn.Unity.dialogueRunner has a custom UnityEvent declared called UnityEvent<string>()
           //When this type of Unity event is called, it has the ability to pass a <string> variable with it
           //When we call our function "CheckNode_CodeListener" you can see we're not passing any data into parantheses.
           //Because the method is being called by an event with data attached, it will automatically get passed,
           //The method listening for the event just needs a string paramter to pass into.
            m_dialogueRunner.onNodeComplete.AddListener(CheckNode_CodeListener);
        }


    }

    //When the object is disabled, you want to make sure you unregister/remove any listeners that
    //Don't need to listen anymore. If you leave to many listeners in your scene, but don't use them,
    //You could cause a memory leak. Just a note if you choose this method
    private void OnDisable()
    {
        //This is less complex than adding, just get rid of it
        m_dialogueRunner.onNodeComplete.RemoveListener(CheckNode_CodeListener);
    }

    //Checks the name of the node against the node names we're looking for.
    private void CheckNode_CodeListener(string _nodeName)
    {
        if (_nodeName == nodeNameToWin)
        {
            //Whatever you want to happen when you win do that here
            Debug.Log("You Win! Called from code listener.");
        }

        if (_nodeName == nodeNameToLose)
        {
            //Whatever you want to happen when they lose do here
            Debug.Log("You Lose! Called from code listener.");
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //This code is THE EXACT SAME as the "CheckNode_CodeListener," I'm just adding it in so I can show
    //How the two methods work exactly the same and how they get called. You may not always have the ability
    //To set a physical connection as a listener for a UnityEvent, hence why the run through of how to set it
    //Through code. 

    public void CheckNode_InspectorListener(string _nodeName)
    {
        if(_nodeName == nodeNameToWin)
        {
            //Whatever you want to happen when you win do that here
            Debug.Log("You Win! Called from Inspector.");
        }

        if (_nodeName == nodeNameToLose)
        {
            //Whatever you want to happen when they lose do here
            Debug.Log("You Lose! Called from Inspector.");
        }
    }
}
