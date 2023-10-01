using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject menu;
    public GameObject menuCamera;
    public GameObject ingamePanel;
    public GameObject playerPrefab;
    public GameObject spawnPoint;

    private GameObject spawnedPlayer;
    

    public void StartHosting()
    {
        spawnedPlayer = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        spawnedPlayer.GetComponent<MovementController>().StartFromRemote();
        menu.SetActive(false);
        menuCamera.SetActive(false);
        ingamePanel.SetActive(true);
        spawnPoint.SetActive(false);
    }

    public void EndHosting()
    {
        menu.SetActive(true);
        menuCamera.SetActive(true);
        ingamePanel.SetActive(false);
        Destroy(spawnedPlayer);
        spawnPoint.SetActive(true);
    }
}
