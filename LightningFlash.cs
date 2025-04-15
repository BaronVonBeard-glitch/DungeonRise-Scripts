using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    private int randomNumGen;
    public GameObject lightning;
    private Light light;
    private AudioSource lightningSound;
    public AudioClip distantLightning;
    public CameraShake cameraShake;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GameObject.Find("Lightning").GetComponent<Light>();
        lightningSound = GameObject.Find("Lightning").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        randomNumGen = Random.Range(0, 100000);
        if (randomNumGen >= 30)
        {
            light.enabled = false;
            //Debug.Log("lightning flash active");
        }
        else if (randomNumGen <= 30)
        {
            light.enabled = true;
            lightningSound.PlayOneShot(distantLightning);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
