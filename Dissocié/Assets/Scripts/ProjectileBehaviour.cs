using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBehaviour : MonoBehaviour
{
        [SerializeField]
        private int velocity = 100;
        private Rigidbody2D rb;

        void Start()
        {
                rb = GetComponent<Rigidbody2D>();

                var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
                var mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                var direction = mouseOnScreen - positionOnScreen;

                rb.AddForce(direction * velocity, ForceMode2D.Impulse);
        }
}
