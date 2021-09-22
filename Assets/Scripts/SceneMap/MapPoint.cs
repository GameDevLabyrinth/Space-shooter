using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameDevLabirinth
{
    [RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
    public class MapPoint : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private TextMeshPro _text;

        [SerializeField]
        private UnityEvent OnClick;
        
        private int _index;

        public void SetParameters(Sprite sprite, int index)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            _index = index;
            _text.text = _index.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            LevelNameData level = new LevelNameData();
            level.SetName("Game"); //HACK: строковое значение имени уровня
            level.SetLevelIndex(_index);
            OnClick.Invoke();
        }
    }
}
