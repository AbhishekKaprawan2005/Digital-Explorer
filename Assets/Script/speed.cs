using UnityEngine;
using UnityEngine.SceneManagement;
namespace acha
{
    public class speed : MonoBehaviour
    {
        public GameObject play;
        public GameObject quit;
        public GameObject title;
        public GameObject com;

        public void playbutton()
        {
            SceneManager.LoadScene("0(2)");
            Time.timeScale = 1f;
            title.SetActive(false);
            play.SetActive(false);
            quit.SetActive(false);
            com.SetActive(true);

        }
        public void quitbutton()
        {
            Application.Quit();
        }
        private void Start()
        {
            title.SetActive(true);
            play.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0f;
 
        }

    }
}