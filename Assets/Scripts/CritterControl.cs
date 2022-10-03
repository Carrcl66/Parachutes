using UnityEngine;
using System.Collections;

public class CritterControl : MonoBehaviour {

    static Camera mainCam = null;
    public bool friend = false;
    public int scoreValue = 0;
    public bool respawn = true;
    AudioSource sound;

    // Use this for initialization
    void Start () {
        // Find the camera from the object tagged as Player.
        if (!mainCam)
            mainCam = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().mainCam;

        // Randomize the initial position based on the screen size above the top of the screen
        float x = Random.Range(10, Screen.width - 9);
        float y = Screen.height + Random.Range(10, 50);

        // then covert it to world coordinates and assign it to the critter.
        Vector3 pos = mainCam.ScreenToWorldPoint(new Vector3(x, y, 0f));
        pos.z = transform.position.z;
        transform.position = pos;

        sound = GetComponent<AudioSource>();
        sound.Play();
    }
    
    // Update is called once per frame
    //void Update () {
    
    //}
}