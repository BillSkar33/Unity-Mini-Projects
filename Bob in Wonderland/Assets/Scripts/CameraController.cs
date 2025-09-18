using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 40f; // Κοινή ταχύτητα κίνησης και περιστροφής
    private Transform ground; // Μεταβλητή για το Transform του εδάφους

    void Start()
    {
        // Αναζητούμε το GameObject του εδάφους με όνομα "Ground" στο Unity Editor
        GameObject groundObject = GameObject.Find("Ground");
        if (!groundObject)
        {
            Debug.LogError("Ground object not found in the scene. Please ensure there is a GameObject named 'Ground'.");
            this.enabled = false; // Απενεργοποίηση του script αν δεν βρεθεί το ground
            return;
        }
        ground = groundObject.transform;
    }


    void Update()
    {
        // Κίνηση προς τα εμπρός και πίσω στον άξονα z της κάμερας
        float forwardMovement = Input.GetAxis("Vertical");
        transform.Translate(0, 0, forwardMovement * speed * Time.deltaTime);

        // Κίνηση πάνω και κάτω στον παγκόσμιο χώρο (στον άξονα y)
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        }

        // Περιστροφή γύρω από τον άξονα y του ground χρησιμοποιώντας το Horizontal axis
        float rotation = Input.GetAxis("Horizontal") * (-speed) * Time.deltaTime;
        transform.RotateAround(ground.position, Vector3.up, rotation);
    }
}
