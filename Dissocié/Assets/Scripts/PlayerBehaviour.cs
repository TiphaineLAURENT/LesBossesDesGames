using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Sprite))]
public class PlayerBehaviour : MonoBehaviour
{
        [SerializeField]
        [RequireNotNull]
        GameObject projectile;

        private void Update()
        {
                var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
                var mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                var angle = AngleBetweenPoints(positionOnScreen, mouseOnScreen) + 90;

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
                {
                        Shoot();
                }
        }

        private float AngleBetweenPoints(Vector3 a, Vector3 b)
        {
                return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

        private void Shoot()
        {
                Instantiate(projectile, transform.position, transform.rotation);
        }
}
