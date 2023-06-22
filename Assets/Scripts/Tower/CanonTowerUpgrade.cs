using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanonTowerUpgrade : Tower, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpgardeCanonUI upgradeUI = GameManager.UI.ShowInGameUI<UpgardeCanonUI>("UI/UpgardeCanonCanvas");
        upgradeUI.SetTarget(this.transform);
        upgradeUI.tower = this;
        upgradeUI.upgradeTowerLV = element;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void UpgradeTower(TowerData data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.towers[element + 1].tower, transform.position, transform.rotation);
    }

    public void SellTower()
    {
        TowerData data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        GameManager.Resource.Destroy(gameObject);
        GameManager.Data.Coin += data.towers[element].sellCost;
        GameManager.Resource.Instantiate<GameObject>("Prefab/TB_BuildingPoint", transform.position, transform.rotation);
    }
}
