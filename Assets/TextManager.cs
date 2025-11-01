//using UnityEngine;
//using UnityEngine.UI;

//public class TextManager : MonoBehaviour
//{
//    public GameObject player1;
//    public GameObject player2;
//    public GameObject winPanel;
//    public Text victoryText;

//    private bool gameEnded = false;

//    void Update()
//    {
//        if (gameEnded) return;

//        if (player1 == null)
//        {
//            ShowVictory("Player 2 Wins!");
//        }
//        else if (player2 == null)
//        {
//            ShowVictory("Player 1 Wins!");
//        }
//    }

//    void ShowVictory(string message)
//    {
//        gameEnded = true;

//        if (winPanel != null)
//            winPanel.SetActive(true);

//        if (victoryText != null)
//            victoryText.text = message;

//        // 可选：暂停游戏
//        Time.timeScale = 0;
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject player1;           // 场景中的 Tank1
    public GameObject player2;           // 场景中的 Tank2
    public GameObject winPanel;          // 胜利界面面板 WinPanel
    public Text victoryText;             // 用于显示胜利信息的 UI Text (WinText)

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        // 判断哪方胜利（哪一方被销毁）
        if (player1 == null)
        {
            ShowVictory("Player 2 Wins!");
        }
        else if (player2 == null)
        {
            ShowVictory("Player 1 Wins!");
        }
    }

    void ShowVictory(string message)
    {
        gameEnded = true;

        string colorMessage = message;

        // 设置胜利主文字颜色
        if (message.Contains("Player 1"))
        {
            ScoreKeeper.player1Wins++;
            colorMessage = "<color=yellow><b>Player 1 Wins!</b></color>";
        }
        else if (message.Contains("Player 2"))
        {
            ScoreKeeper.player2Wins++;
            colorMessage = "<color=#00FFFF><b>Player 2 Wins!</b></color>"; // 青蓝色
        }

        // 显示面板
        if (winPanel != null)
            winPanel.SetActive(true);

        // 拼接文字：胜利标题 + 统计行
        if (victoryText != null)
        {
            victoryText.text = colorMessage + "\n\n"
                + "<color=yellow><b>P1 胜利次数:</b></color> " + ScoreKeeper.player1Wins + "    "
                + "<color=#00FFFF><b>P2 胜利次数:</b></color> " + ScoreKeeper.player2Wins;
        }

        Time.timeScale = 0f;
    }

}

