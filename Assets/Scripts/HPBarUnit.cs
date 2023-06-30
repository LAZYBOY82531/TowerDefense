using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUnit : MonoBehaviour
{
    [SerializeField] UnitController unit;
    [SerializeField] TMP_Text HP;
    [SerializeField] TMP_Text FullHP;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = unit.HP;
        slider.value = unit.HP;
        HP.text = unit.HP.ToString();
        FullHP.text = unit.fullHP.ToString();
        unit.OnChangedHP.AddListener((hp) => { slider.value = hp; });
        unit.OnChangedHP.AddListener((hp) => { HP.text = hp.ToString(); });
    }
}
