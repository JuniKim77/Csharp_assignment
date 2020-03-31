using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("Editor Objects")]
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public Transform nextNode;
    public Transform poolNode;
    public Transform[] nextList = new Transform[3];
    public GameManager gameManager;

    [Header("Game Settings")]
    [Range(4, 40)]
    public int boardWidth = 10;
    [Range(5, 20)]
    public int boardHeight = 20;

    private int halfWidth;
    private int halfHeight;
    private float nextFallTime;
    private MemoryPool pool = new MemoryPool();
    private int count = 0;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        halfWidth = Mathf.RoundToInt(boardWidth * 0.5f);
        halfHeight = Mathf.RoundToInt(boardHeight * 0.5f);
        nextFallTime = Time.time + gameManager.fallCycle;

        pool.Create(tilePrefab, 600, poolNode);

        CreateBackground();

        for (int i = 0; i < boardHeight; ++i)
        {
            GameObject row = new GameObject((boardHeight - i - 1).ToString());
            row.transform.position = new Vector3(0, halfHeight - i, 0);
            row.transform.parent = boardNode;
        }

        InitializeTetrominos();
        GetNextTetromino();
    }

    void CreateBackground()
    {
        Color color = Color.gray;

        color.a = 0.5f;
        for (int x = -halfWidth; x < halfWidth; ++x)
        {
            for (int y = halfHeight; y > -halfHeight; --y)
            {
                CreateTile(backgroundNode, new Vector2(x, y), color, 0);
            }
        }

        color.a = 1.0f;
        for (int y = halfHeight; y > -halfHeight; --y)
        {
            CreateTile(backgroundNode, new Vector2(-halfWidth - 1, y), color, 0);
            CreateTile(backgroundNode, new Vector2(halfWidth, y), color, 0);
        }

        for (int x = -halfWidth - 1; x <= halfWidth; ++x)
        {
            CreateTile(backgroundNode, new Vector2(x, -halfHeight), color, 0);
        }
        color.a = 0.5f;
        for (int x = -1; x < 3; ++x)
        {
            for (int y = halfHeight - 2; y > -3; --y)
            {
                CreateTile(nextNode, new Vector2(x, y), color, 0);
            }
        }
    }
    Tile CreateTile(Transform parent, Vector2 position, Color color, int order = 1)
    {
        var go = pool.NewItem();
        go.transform.parent = parent;
        go.transform.localPosition = position;

        Tile tile = go.GetComponent<Tile>();
        tile.color = color;
        tile.sortingOrder = order;

        return tile;
    }
    void CreateTetromino(Transform parent)
    {
        Color32 color = Color.white;
        int index = 0;
        if (gameManager.generalValues.gameType == 0)
        {
            index = Random.Range(0, 7);
        }
        else if (gameManager.generalValues.gameType == 1)
        {
            index = Random.Range(0, 12);
        }

        parent.rotation = Quaternion.identity;

        switch (index)
        {
            // I : 하늘색
            case 0:
                color = new Color32(115, 251, 253, 255);
                CreateTile(parent, new Vector2(-1f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(1f, 0.0f), color);
                CreateTile(parent, new Vector2(2f, 0.0f), color);
                break;

            // J : 파란색
            case 1:
                color = new Color32(0, 33, 245, 255);
                CreateTile(parent, new Vector2(-1f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(1f, 0.0f), color);
                CreateTile(parent, new Vector2(-1f, 1.0f), color);
                break;

            // L : 귤색
            case 2:
                color = new Color32(243, 168, 59, 255);
                CreateTile(parent, new Vector2(-1f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(1f, 0.0f), color);
                CreateTile(parent, new Vector2(1f, 1.0f), color);
                break;

            // O : 노란색
            case 3:
                color = new Color32(255, 253, 84, 255);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                break;

            // S : 녹색
            case 4:
                color = new Color32(117, 250, 76, 255);
                CreateTile(parent, new Vector2(-1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                break;

            // T : 자주색
            case 5:
                color = new Color32(155, 47, 246, 255);
                CreateTile(parent, new Vector2(-1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                break;

            // Z : 빨간색
            case 6:
                color = new Color32(235, 51, 35, 255);
                CreateTile(parent, new Vector2(-1f, 1f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                break;
            // ㄷ : 연두색
            case 7:
                color = new Color32(129, 193, 71, 255);
                CreateTile(parent, new Vector2(-1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(-1f, 1f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                break;
            // 배모양 : 분홍색
            case 8:
                color = new Color32(255, 183, 171, 255);
                CreateTile(parent, new Vector2(-1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(2f, 0f), color);
                break;
            // 배모양 : 하늘색
            case 9:
                color = new Color32(80, 206, 223, 255);
                CreateTile(parent, new Vector2(-1f, 0f), color);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                CreateTile(parent, new Vector2(2f, 0f), color);
                break;
            // 굿모양 : 연노랑
            case 10:
                color = new Color32(255, 212, 0, 255);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                CreateTile(parent, new Vector2(1f, 2f), color);
                break;
            // 굿모양 : 분홍색
            case 11:
                color = new Color32(144, 238, 144, 255);
                CreateTile(parent, new Vector2(0f, 0f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(1f, 0f), color);
                CreateTile(parent, new Vector2(1f, 1f), color);
                CreateTile(parent, new Vector2(0f, 2f), color);
                break;
            default:
                Debug.LogError("Error when making tetromino.");
                break;
        }
    }

    void InitializeTetrominos()
    {

        Color32 color = Color.white;

        for (int i = 0; i < 3; ++i)
        {
            CreateTetromino(nextList[i]);
        }
    }
    void GetNextTetromino()
    {
        tetrominoNode.rotation = Quaternion.identity;
        tetrominoNode.transform.position = new Vector2(0, halfHeight);
        var target = tetrominoNode;
        for (int i = 0; i < 3; ++i)
        {
            var fromNode = nextList[i];
            while (fromNode.childCount > 0)
            {
                var node = fromNode.GetChild(0);
                float x = node.localPosition.x;
                float y = node.localPosition.y;
                node.parent = target;
                node.transform.localPosition = new Vector2(x, y);
            }
            fromNode.DetachChildren();
            target = nextList[i];
        }
        CreateTetromino(nextList[2]);
    }

    private void Update()
    {
        Vector3 moveDir = Vector2.zero;
        bool isRotate = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (gameManager.gameoverPanel.activeSelf)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDir.x = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isRotate = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDir.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            while (MoveTetromino(Vector3.down, false))
            {
            }
        }
        if (Time.time > nextFallTime)
        {
            nextFallTime = Time.time + gameManager.fallCycle;
            moveDir = Vector3.down;
            isRotate = false;
            count++;
        }

        if (count >= gameManager.addBlocsCycle)
        {
            AddBlocks(2);
            count = 0;
        }

        if (moveDir != Vector3.zero || isRotate)
        {
            MoveTetromino(moveDir, isRotate);
        }
    }

    bool MoveTetromino(Vector3 moveDir, bool isRotate)
    {
        Vector3 oldPos = tetrominoNode.transform.position;
        Quaternion oldRot = tetrominoNode.transform.rotation;

        tetrominoNode.transform.position += moveDir;
        if (isRotate)
        {
            tetrominoNode.transform.rotation *= Quaternion.Euler(0, 0, 90);
        }

        if (CanMoveTo(tetrominoNode) == false)
        {
            tetrominoNode.transform.position = oldPos;
            tetrominoNode.transform.rotation = oldRot;

            if ((int)moveDir.y == -1 && (int)moveDir.x == 0 && isRotate == false)
            {
                AddToBoard(tetrominoNode);
                CheckBoardRow();
                GetNextTetromino();

                if (CanMoveTo(tetrominoNode) == false)
                {
                    gameManager.GameOver();
                }
            }

            return false;
        }

        return true;
    }
    bool CanMoveTo(Transform root)
    {
        for (int i = 0; i < root.childCount; ++i)
        {
            Transform node = root.GetChild(i);
            int x = Mathf.RoundToInt(node.transform.position.x + halfWidth);
            int y = Mathf.RoundToInt(node.transform.position.y + halfHeight - 1);

            if (x < 0 || x > boardWidth - 1)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }

            var row = boardNode.Find(y.ToString());

            if (row != null && row.Find(x.ToString()) != null)
            {
                return false;
            }
        }

        return true;
    }
    void AddToBoard(Transform root)
    {
        while (root.childCount > 0)
        {
            var node = root.GetChild(0);

            int x = Mathf.RoundToInt(node.transform.position.x + halfWidth);
            int y = Mathf.RoundToInt(node.transform.position.y + halfHeight - 1);

            node.parent = boardNode.Find(y.ToString());
            node.name = x.ToString();
        }
    }

    void CheckBoardRow()
    {
        bool isCleared = false;
        int count = 0;
        foreach (Transform row in boardNode)
        {
            if (row.childCount == boardWidth)
            {
                count++;
                foreach (Transform each in row)
                {
                    pool.RemoveItem(each.gameObject);
                }

                row.DetachChildren();
                isCleared = true;
            }
        }
        gameManager.IncreseScore(count);

        if (isCleared)
        {
            int target = 0;
            for (int i = 0; i < boardNode.childCount; ++i)
            {
                var row = boardNode.Find(i.ToString());

                if (row.childCount == 0)
                {
                    continue;
                }
                if (i != target)
                {
                    var targetNode = boardNode.Find(target.ToString());
                    while (row.childCount > 0)
                    {
                        var node = row.GetChild(0);
                        node.parent = targetNode;
                        node.transform.localPosition = new Vector2(node.localPosition.x, 0);
                    }
                    row.DetachChildren();
                }
                target++;
            }
        }
    }
    public void AddBlocks(int num)
    {
        if (num <= 0)
        {
            return;
        }
        for (int i = boardNode.childCount - num; i >= 0; --i)
        {
            var row = boardNode.Find(i.ToString());
            if (row.childCount == 0)
            {
                continue;
            }
            int target = i + num;
            var targetNode = boardNode.Find(target.ToString());
            while (row.childCount > 0)
            {
                var node = row.GetChild(0);
                node.parent = targetNode;
                node.transform.localPosition = new Vector2(node.localPosition.x, 0);
            }
            row.DetachChildren();
        }
        Color32 blankColor = new Color32(150, 75, 0, 127);
        for (int i = 0; i < num; ++i)
        {
            var row = boardNode.Find(i.ToString());
            int blank = Random.Range(-5, 5);
            for (int j = -5; j < blank; ++j)
            {
                CreateTile(row, new Vector2(j, 0), blankColor);
            }
            for (int j = blank + 1; j < 5; ++j)
            {
                CreateTile(row, new Vector2(j, 0), blankColor);
            }
            for (int k = 0; k < row.childCount; ++k)
            {
                var node = row.GetChild(k);
                node.name = k.ToString();
            }
        }
    }

    public void Rotate()
    {
        MoveTetromino(Vector3.zero, true);
    }
    public void MoveRight()
    {
        MoveTetromino(Vector3.right, false);
    }
    public void MoveLeft()
    {
        MoveTetromino(Vector3.left, false);
    }
    public void MoveBottom()
    {
        while (MoveTetromino(Vector3.down, false))
        {
        }
    }
}
