using System.Text;
using TMPro;
using UnityEngine;


public class ItemToolTip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemNameText;
    [SerializeField] TextMeshProUGUI ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip (Item item)
    {
        ItemNameText.text = item.ItemObject.itemName;

        sb.Length = 0;
        AddStat(item.EnduranceModifier.Value, "Endurance");
        AddStat(item.IntelligenceModifier.Value, "Intelligence");
        AddStat(item.SurvivabilityModifier.Value, "Survivability");

/*        AddStat(item.EnduranceModifier.Value, "Endurance", isPercent: true);
        AddStat(item.IntelligenceModifier.Value, "Intelligence", isPercent: true);
        AddStat(item.SurvivabilityModifier.Value, "Survivability", isPercent: true);*/

        ItemStatsText.text = sb.ToString();

    }

    public void HideToolTip()
    {
        ItemNameText.text = "";
        ItemStatsText.text = "";
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (value > 0)
                sb.Append("+");

            if (isPercent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            } else {
                sb.Append(value);
                sb.Append(" ");
            }
            sb.Append(statName);
        }
        
    }

}
