using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private Dropdown dropdownSelectManagment;

    [SerializeField]
    private GameObject panelPause;

    [SerializeField]
    private GameObject canvas;

    private ManagmentObservable managment;
    private IPlayer player;

    void Start()
    {
        player = new Player(canvas, dropdownSelectManagment);
        managment = new ManagmentMove();
        managment.RegisterObserver(player);
        managment.NotifyObservers();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        panelPause.SetActive(true);
    }

    public void ResumeGame()
    {
        managment.NotifyObservers();
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
