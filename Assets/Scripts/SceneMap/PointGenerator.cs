using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public class PointGenerator : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private MapPoint _pointplayable;

        [SerializeField, AttentionField]
        private GameObject _pointLocked;

        [SerializeField, AttentionField]
        private GameObject _path;

        [SerializeField]
        private List<Sprite> _sprites;

        [SerializeField]
        private UnityEvent OnGenerated;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            PointStates pointStates = new PointStates();
            pointStates.States.Add(PointState.OneStar);
            pointStates.States.Add(PointState.Open);
            pointStates.States.Add(PointState.TwoStars);
            pointStates.States.Add(PointState.ThreeStars);
            pointStates.States.Add(PointState.Locked);
            pointStates.States.Add(PointState.Locked);
            pointStates.States.Add(PointState.Locked);


            PointPosition pointPosition = new PointPosition();
            Vector2 currentPosition;
            List<Vector2> pointPositions = new List<Vector2>();

            for (int i = 0; i < pointStates.States.Count; i++)
            {
                currentPosition = pointPosition.GetNextPosition();
                pointPositions.Add(currentPosition);

                if (pointStates.States[i] == PointState.Locked)
                    Instantiate(_pointLocked, transform).transform.position = currentPosition;
                else
                {
                    MapPoint point = Instantiate(_pointplayable, transform);
                    point.transform.position = currentPosition;

                    Sprite sprite = null;

                    switch (pointStates.States[i])
                    {
                        case PointState.Open:
                            sprite = _sprites[1];
                            break;
                        case PointState.OneStar:
                            sprite = _sprites[2];
                            break;
                        case PointState.TwoStars:
                            sprite = _sprites[3];
                            break;
                        case PointState.ThreeStars:
                            sprite = _sprites[4];
                            break;
                    }

                    point.SetParameters(sprite, i);
                }

            }

            for (int i = 0; i < pointPositions.Count - 1; i++)
            {
                currentPosition = (pointPositions[i] + pointPositions[i + 1]) / 2;

                var path = Instantiate(_path, transform);
                path.transform.position = currentPosition;

                var vector = pointPositions[i + 1] - pointPositions[i];
                var zRotate = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
                path.transform.Rotate(0, 0, zRotate);
            }

            OnGenerated.Invoke();
        }
    }
}