using DG.Tweening;
using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public event Action OnMoveEvent = delegate { };

    public bool IsBusy { get; private set; }

    private Board m_board;

    private GameManager m_gameManager;

    private bool m_isDragging;

    private Camera m_cam;

    private Collider2D m_hitCollider;

    private GameSettings m_gameSettings;

    private List<Cell> m_potentialMatch;

    private float m_timeAfterFill;

    private bool m_hintIsShown;

    private bool m_gameOver;

    GameObject table;

    public Transform objectCount;

    CharacterController character;

    MMFeedbacks feedbacks;
    public void StartGame(GameManager gameManager, GameSettings gameSettings)
    {
        feedbacks = GameObject.Find("Feels").transform.GetChild(0).GetComponent<MMFeedbacks>();
        table = GameObject.Find("Table");
        character = GameObject.Find("Chef").GetComponent<CharacterController>();

        m_gameManager = gameManager;

        m_gameSettings = gameSettings;

        m_gameManager.StateChangedAction += OnGameStateChange;

        m_cam = GameObject.Find("Orto").GetComponent<Camera>();

        m_board = new Board(this.transform, gameSettings);

        transform.position = new Vector3(-0.4f, -10.8f, 1.5f);
        transform.Rotate(new Vector3(30f, 0f, 0f));
        Fill();
    }

    private void Fill()
    {
        m_board.Fill();
        FindMatchesAndCollapse();
    }

    private void OnGameStateChange(GameManager.eStateGame state)
    {
        switch (state)
        {
            case GameManager.eStateGame.GAME_STARTED:
                IsBusy = false;
                break;
            case GameManager.eStateGame.PAUSE:
                IsBusy = true;
                break;
            case GameManager.eStateGame.GAME_OVER:
                m_gameOver = true;
                StopHints();
                break;
        }
    }


    public void Update()
    {


        if (objectCount == null && GameObject.Find("ObjectCount").activeSelf)
        {
            objectCount = GameObject.Find("ObjectCount").transform;
        }

        if (m_gameOver) return;
        if (IsBusy) return;

        if (!m_hintIsShown)
        {

            m_timeAfterFill += Time.deltaTime;
            if (m_timeAfterFill > m_gameSettings.TimeForHint)
            {
                m_timeAfterFill = 0f;
                ShowHint();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            restTime = 0;
            var hit = Physics2D.Raycast(m_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                m_isDragging = true;
                m_hitCollider = hit.collider;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetRayCast();
        }

        if (Input.GetMouseButton(0) && m_isDragging)
        {
            var hit = Physics2D.Raycast(m_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (m_hitCollider != null && m_hitCollider != hit.collider)
                {
                    StopHints();

                    Cell c1 = m_hitCollider.GetComponent<Cell>();
                    Cell c2 = hit.collider.GetComponent<Cell>();
                    if (AreItemsNeighbor(c1, c2))
                    {
                        IsBusy = true;
                        SetSortingLayer(c1, c2);
                        m_board.Swap(c1, c2, () =>
                        {
                            FindMatchesAndCollapse(c1, c2);
                        });

                        ResetRayCast();
                    }
                }
            }
            else
            {
                ResetRayCast();
            }
        }
    }

    private void ResetRayCast()
    {
        m_isDragging = false;
        m_hitCollider = null;
    }

    private void FixBoard()
    {



        for (int i = 0; i < 63; i++)
        {
            if (transform.GetChild(i).GetComponent<Cell>().Item.View == null)
            {
                transform.GetChild(i).GetComponent<Cell>().Free();
                m_board.FillGapsWithNewItems();
                break;
            }
        }

        //if (transform.childCount > 63)
        //{
        //    m_board.ExplodeAllItems();
        //    m_board.Fill();
        //}

    }
    private void FindMatchesAndCollapse(Cell cell1, Cell cell2)
    {


        if (cell1.Item is BonusItem)
        {
            cell1.ExplodeItem();
            StartCoroutine(ShiftDownItemsCoroutine());
        }
        else if (cell2.Item is BonusItem)
        {
            cell2.ExplodeItem();
            StartCoroutine(ShiftDownItemsCoroutine());
        }
        else
        {
            List<Cell> cells1 = GetMatches(cell1);
            List<Cell> cells2 = GetMatches(cell2);

            List<Cell> matches = new List<Cell>();
            matches.AddRange(cells1);
            matches.AddRange(cells2);
            matches = matches.Distinct().ToList();

            if (matches.Count < m_gameSettings.MatchesMin)
            {

                m_board.Swap(cell1, cell2, () =>
                {
                    IsBusy = false;
                });
            }
            else
            {
                OnMoveEvent();

                CollapseMatches(matches, cell2);
            }
        }
    }

    private void FindMatchesAndCollapse()
    {
        List<Cell> matches = m_board.FindFirstMatch();

        if (matches.Count > 0)
        {
            CollapseMatches(matches, null);
        }
        else
        {
            m_potentialMatch = m_board.GetPotentialMatches();
            if (m_potentialMatch.Count > 0)
            {
                IsBusy = false;

                m_timeAfterFill = 0f;
            }
            else
            {
                //StartCoroutine(RefillBoardCoroutine());
                StartCoroutine(ShuffleBoardCoroutine());
            }
        }
    }

    private List<Cell> GetMatches(Cell cell)
    {
        List<Cell> listHor = m_board.GetHorizontalMatches(cell);
        if (listHor.Count < m_gameSettings.MatchesMin)
        {
            listHor.Clear();

        }

        List<Cell> listVert = m_board.GetVerticalMatches(cell);
        if (listVert.Count < m_gameSettings.MatchesMin)
        {
            listVert.Clear();
        }

        return listHor.Concat(listVert).Distinct().ToList();

    }

    private void CollapseMatches(List<Cell> matches, Cell cellEnd)
    {
        for (int i = 0; i < matches.Count; i++)
        {
            if (i == 0)
            {

                GameObject obj = Instantiate(matches[0].Item.View.gameObject, matches[0].transform.position, Quaternion.identity);
                obj.transform.localScale = Vector3.zero;
                StartCoroutine(MoveToTable(obj));

            }
            matches[i].ExplodeItem();
        }
        feedbacks.PlayFeedbacks();
        if (matches.Count > m_gameSettings.MatchesMin)
        {
            m_board.ConvertNormalToBonus(matches, cellEnd);
        }

        StartCoroutine(ShiftDownItemsCoroutine());
    }


    private IEnumerator ShiftDownItemsCoroutine()
    {
        m_board.ShiftDownItems();

        yield return new WaitForSeconds(0.2f);

        m_board.FillGapsWithNewItems();

        yield return new WaitForSeconds(0.2f);

        FindMatchesAndCollapse();

        yield return new WaitForSeconds(0.3f);
        FixBoard();
        FindMatchesAndCollapse();
    }

    private IEnumerator RefillBoardCoroutine()
    {
        m_board.ExplodeAllItems();

        yield return new WaitForSeconds(0.2f);

        m_board.Fill();

        yield return new WaitForSeconds(0.2f);

        FindMatchesAndCollapse();
    }

    private IEnumerator ShuffleBoardCoroutine()
    {
        m_board.Shuffle();

        yield return new WaitForSeconds(0.3f);

        FindMatchesAndCollapse();
    }


    private void SetSortingLayer(Cell cell1, Cell cell2)
    {
        if (cell1.Item != null) cell1.Item.SetSortingLayerHigher();
        if (cell2.Item != null) cell2.Item.SetSortingLayerLower();
    }

    private bool AreItemsNeighbor(Cell cell1, Cell cell2)
    {
        return cell1.IsNeighbour(cell2);
    }

    internal void Clear()
    {
        m_board.Clear();
    }

    private void ShowHint()
    {
        m_hintIsShown = true;
        foreach (var cell in m_potentialMatch)
        {
            cell.AnimateItemForHint();
        }
    }

    private void StopHints()
    {
        m_hintIsShown = false;
        foreach (var cell in m_potentialMatch)
        {
            cell.StopHintAnimation();
        }

        m_potentialMatch.Clear();
    }

    float restTime = 0;
    IEnumerator MoveToTable(GameObject obj)
    {
        restTime = 0;
        for (int i = 0; i < objectCount.childCount; i++)
        {
            if (obj.name.Contains(objectCount.GetChild(i).name))
            {
                objectCount.GetChild(i).GetComponent<Animator>().SetTrigger("blob");
                objectCount.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = (int.Parse(objectCount.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text) + 1).ToString();
                //character.NextPartBusy();

                break;
            }
        }
        Destroy(obj);
        yield return new WaitForSeconds(0.01f);

        //obj.GetComponent<MeshCollider>().enabled = true;
        //obj.GetComponent<Rigidbody>().isKinematic = false;
        //Vector3 goPos = Vector3.zero;
        //Transform tableObj = null;

        //for (int i = 0; i < table.transform.childCount; i++)
        //{
        //    if (obj.transform.name.Contains(table.transform.GetChild(i).name))
        //    {
        //        tableObj = table.transform.GetChild(i);
        //        goPos = table.transform.GetChild(i).transform.position;
        //    }
        //}

        //float j = 0.0f;
        //float rate = (1.0f / 2) * 3;
        //goPos.y = table.transform.position.y + 1;
        //while (j < 0.4f)
        //{
        //    j += Time.deltaTime * rate;
        //    obj.transform.position = Vector3.Lerp(obj.transform.position,
        //        goPos, j);
        //    yield return null;
        //}


        //tableObj.GetChild(1).GetComponent<Animator>().SetTrigger("OpenBox");
        //Destroy(obj);
    }
}
