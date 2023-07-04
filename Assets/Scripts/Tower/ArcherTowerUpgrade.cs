using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherTowerUpgrade : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Tower tower;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        tower = GetComponent<Tower>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpgardeArcherUI upgradeUI = GameManager.UI.ShowInGameUI<UpgardeArcherUI>("UI/UpgardeArcherCanvas");
        upgradeUI.SetTarget(this.transform);
        upgradeUI.tower = this;
        upgradeUI.upgradeTowerLV = tower.element;
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
        GameManager.Resource.Instantiate(data.towers[tower.element + 1].tower, transform.position, transform.rotation);
    }

    public void SellTower()
    {
        TowerData data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        GameManager.Resource.Destroy(gameObject);
        GameManager.Data.Coin += data.towers[tower.element].sellCost;
        GameManager.Resource.Instantiate<GameObject>("Prefab/TB_BuildingPoint", transform.position, transform.rotation);
    }
}
