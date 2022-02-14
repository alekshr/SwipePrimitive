using UnityEngine;
using UnityEngine.UI;



class Player : IPlayer
{

    private GameObject canvas;
    private Dropdown dropdownSelectManagment;

    public Player(GameObject canvas, Dropdown dropdownSelectManagment)
    {
        this.canvas = canvas;
        this.dropdownSelectManagment = dropdownSelectManagment;
    }


    public void Update()
    {
        DeleteManagment();
        switch (dropdownSelectManagment.value)
        {
            case 0:
                canvas.AddComponent<KeyboardManager>();
                break;
            case 1:
                canvas.AddComponent<SwipeManager>();
                break;
            case 2:
                canvas.AddComponent<DragManager>();
                break;
        }

    }

    private void DeleteManagment()
    {
        if (canvas.GetComponent<KeyboardManager>() != null)
        {
            Object.Destroy(canvas.GetComponent<KeyboardManager>());
        }
        if (canvas.GetComponent<DragManager>() != null)
        {
            Object.Destroy(canvas.GetComponent<DragManager>());
        }
        if (canvas.GetComponent<SwipeManager>() != null)
        {
            Object.Destroy(canvas.GetComponent<SwipeManager>());
        }
    }

}
