
using UnityEngine;

public class Pausethegame : MonoBehaviour
{
     bool isPause = false;

    public void Pause()
    {
        if(isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }

        else
        {
            Time.timeScale = 0;
            isPause = true;

        }
    }
}
