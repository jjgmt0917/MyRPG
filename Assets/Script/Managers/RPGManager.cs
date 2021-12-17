
using UnityEngine;

public class RPGManager : MonoBehaviour
{
    public static RPGManager sharedInstance = null;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
