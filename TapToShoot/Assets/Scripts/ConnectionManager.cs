using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using SocketIO;

public class ConnectionManager : MonoBehaviour
{

    public SocketIOComponent socket;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(ConnectToServer());
        socket.On("USER_CONNECTED", OnUserConnected);
        socket.On("USER_DISCONNECTED", OnUserDisconnected);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnUserConnected(SocketIOEvent evt)
    {
        Debug.Log("Message from server is : " + evt.data + "OnUserConnected");
    }

    string JsonToString(string target, string s)
    {
        string[] newString = Regex.Split(target, s);
        return newString[1];
    }

    Vector3 JsonToVector3(string target)
    {
        Vector3 newVector;
        string[] newString = Regex.Split(target, ",");
        newVector = new Vector3(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));

        return newVector;
    }

    void OnUserDisconnected(SocketIOEvent obj)
    {

    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(.5f);
        socket.Emit("USER_CONNECT");
    }
}
