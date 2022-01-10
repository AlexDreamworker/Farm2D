using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 3f;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
