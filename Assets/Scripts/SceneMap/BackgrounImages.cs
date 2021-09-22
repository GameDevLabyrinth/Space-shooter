using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class BackgrounImages : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> _sprites;

        private float _offsetY = 0f;

        private void Start()
        {
            if (_sprites.Count > 0)
                SetImagesPosition();
        }

        private void SetImagesPosition()
        {
            transform.position = new Vector2(transform.position.x, new SafeAreaData().GetMin().y);

            for (int i = 0; i < _sprites.Count; i++)
            {
                GameObject image = new GameObject("image", typeof(SpriteRenderer));
                image.GetComponent<SpriteRenderer>().sprite = _sprites[i];
                image.transform.SetParent(transform);
                image.transform.position = new Vector2(transform.position.x, transform.position.y + _offsetY);
                _offsetY += _sprites[i].bounds.size.y;
            }
        }
    }
}
