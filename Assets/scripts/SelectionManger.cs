
using System;

using UnityEngine;



public class SelectionManger : MonoBehaviour
{
    [SerializeField] private GameObject leftColumn, rightColumn, target;
    [SerializeField] private int pairesNumber;
    [SerializeField] private int pairesCounter;
    [SerializeField] private Tuple<GameObject, GameObject>[] tuples;
    [SerializeField] private bool SoloSelection;
    private void init()
    {
        leftColumn = null;
        rightColumn = null;
    }
    private void Start()
    {
        tuples = new Tuple<GameObject, GameObject>[pairesNumber];
        pairesCounter = 0;
        init();
    }



    // Update is called once per frame
    private bool dragDone = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            UnityEngine.Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, UnityEngine.Vector2.zero);
            target = (hit.collider) ? hit.collider.gameObject : null;

            if (SoloSelection)
            {
                if (target && hit.collider.gameObject.GetComponent<ImagetoConnect>().state != ImagetoConnect.STATE.CONNECTED)
                {


                    if (target.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT)
                    {
                        if (leftColumn == null)
                        {
                            leftColumn = target;
                            target.GetComponent<FollowMouse>().enabled = true;
                            target.GetComponent<LineRenderer>().enabled = true;
                            leftColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;
                        }
                    }
                    else
                    {
                        if (rightColumn == null)
                        {
                            rightColumn = target;
                            target.GetComponent<FollowMouse>().enabled = true;
                            target.GetComponent<LineRenderer>().enabled = true;
                            rightColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;

                        }
                    }

                    if (leftColumn && rightColumn)
                    {
                        //saving line renderer
                        tuples[pairesCounter++] = new Tuple<GameObject, GameObject>(leftColumn, rightColumn);
                        leftColumn.GetComponent<FollowMouse>().enabled = false;
                        rightColumn.GetComponent<FollowMouse>().enabled = false;
                        LineRenderer leftLineRenderer = leftColumn.GetComponent<LineRenderer>();
                        LineRenderer rightLineRenderer = rightColumn.GetComponent<LineRenderer>();
                        leftLineRenderer.enabled = true;
                        rightLineRenderer.enabled = false;
                        leftLineRenderer.SetPosition(0, leftColumn.transform.Find("CheckBox").position);
                        leftLineRenderer.SetPosition(1, rightColumn.transform.Find("CheckBox").position);
                        leftColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;
                        rightColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;

                        leftColumn.GetComponent<ImagetoConnect>().connectedTo = rightColumn.GetComponent<ImagetoConnect>().index;
                        rightColumn.GetComponent<ImagetoConnect>().connectedTo = leftColumn.GetComponent<ImagetoConnect>().index;





                        init();
                    }

                }
                else
                {

                    if (target && target.gameObject.GetComponent<ImagetoConnect>().state == ImagetoConnect.STATE.CONNECTED)
                    {
                        if (!leftColumn && !rightColumn)
                        {
                            Tuple<GameObject, GameObject> paire = ExistInExistedPaires(target);
                            deleteExistingTuple(target);
                            if (paire != null)
                            {
                                paire.Item1.GetComponent<ImagetoConnect>().connectedTo = -1;
                                paire.Item2.GetComponent<ImagetoConnect>().connectedTo = -1;
                                bool isleft = target.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT;
                                if (isleft)
                                {
                                    paire.Item1.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;
                                    paire.Item1.GetComponent<LineRenderer>().enabled = false;
                                    paire.Item2.GetComponent<LineRenderer>().enabled = true;
                                    paire.Item2.GetComponent<FollowMouse>().enabled = true;
                                    rightColumn = paire.Item2;

                                }
                                else
                                {
                                    paire.Item2.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;
                                    paire.Item1.GetComponent<LineRenderer>().enabled = true;
                                    paire.Item1.GetComponent<FollowMouse>().enabled = true;

                                    leftColumn = paire.Item1;
                                }

                            }
                        }
                        else
                        {
                            if (leftColumn && target.GetInstanceID() == leftColumn.GetInstanceID())
                            {
                                leftColumn = null;
                                target.GetComponent<FollowMouse>().enabled = false;
                                target.GetComponent<LineRenderer>().enabled = false;
                                target.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;

                            }
                            else
                            {
                                if (rightColumn && target.GetInstanceID() == rightColumn.GetInstanceID())
                                {
                                    rightColumn = null;
                                    target.GetComponent<FollowMouse>().enabled = false;
                                    target.GetComponent<LineRenderer>().enabled = false;
                                    target.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;
                                }
                            }
                        }


                    }

                }
            }
            else
            {
                if (target)
                {

                    if (!leftColumn)
                    {
                        if (target.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT)
                        {
                            if (target.GetComponent<ImagetoConnect>().state == ImagetoConnect.STATE.NOT_CONNECTED)
                            {
                                leftColumn = target;
                                target.GetComponent<FollowMouse>().enabled = true;
                                target.GetComponent<LineRenderer>().enabled = true;
                                leftColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;
                            }
                            else
                            {
                                target.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;
                                target.GetComponent<LineRenderer>().enabled = false;
                                target.GetComponent<ImagetoConnect>().connectedTo = -1;
                                deleteExistingTuple(target);

                            }

                        }
                    }
                    else
                    {

                        if (target.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT)
                        {
                            if (target.GetInstanceID() == leftColumn.GetInstanceID())
                            {
                                leftColumn = null;
                                target.GetComponent<FollowMouse>().enabled = false;
                                target.GetComponent<LineRenderer>().enabled = false;
                                target.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.NOT_CONNECTED;
                            }
                        }
                        else
                        {
                            rightColumn = target;
                            //saving line renderer
                            tuples[pairesCounter++] = new Tuple<GameObject, GameObject>(leftColumn, rightColumn);
                            leftColumn.GetComponent<FollowMouse>().enabled = false;
                            rightColumn.GetComponent<FollowMouse>().enabled = false;
                            LineRenderer leftLineRenderer = leftColumn.GetComponent<LineRenderer>();
                            LineRenderer rightLineRenderer = rightColumn.GetComponent<LineRenderer>();
                            leftLineRenderer.enabled = true;
                            rightLineRenderer.enabled = false;
                            if (leftColumn.GetComponent<ImagetoConnect>().leftToMiddle)
                            {
                                leftLineRenderer.SetPosition(1, rightColumn.transform.Find("CheckBox").position);
                            }
                            else
                            {
                                leftLineRenderer.SetPosition(1, rightColumn.transform.Find("CheckBox 2").position);
                            }

                            leftColumn.GetComponent<ImagetoConnect>().connectedTo = rightColumn.GetComponent<ImagetoConnect>().index;
                            leftColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;
                            rightColumn.GetComponent<ImagetoConnect>().state = ImagetoConnect.STATE.CONNECTED;






                            init();
                        }
                    }
                }
            }


        }


    }

    private void deleteExistingTuple(GameObject obj)
    {
        bool isLeft = obj.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT;
        int i = 0;
        if (isLeft)
        {
            while (i < pairesCounter && obj.GetInstanceID() != tuples[i].Item1.GetInstanceID())
            {
                i++;
            }
        }
        else
        {
            while (i < pairesCounter && obj.GetInstanceID() != tuples[i].Item2.GetInstanceID())
            {
                i++;
            }
        }
        if (i < pairesCounter)
        {
            tuples[i] = (i + 1 == pairesNumber) ? null : tuples[pairesCounter - 1];

            pairesCounter--;
        }
    }
    private Tuple<GameObject, GameObject> ExistInExistedPaires(GameObject obj)
    {
        bool isLeft = obj.GetComponent<ImagetoConnect>().line == ImagetoConnect.LINE.LEFT;
        int i = 0;
        if (isLeft)
        {
            while (i < pairesCounter && obj.GetInstanceID() != tuples[i].Item1.GetInstanceID())
            {
                i++;
            }
        }
        else
        {
            while (i < pairesCounter && obj.GetInstanceID() != tuples[i].Item2.GetInstanceID())
            {
                i++;
            }
        }

        return (i < pairesCounter) ? tuples[i] : null;
    }
}
