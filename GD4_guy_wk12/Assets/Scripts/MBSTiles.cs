using AStar.Algolgorithms;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MBSTiles : MonoBehaviour
{
    [SerializeField] Tilemap tilFog;
    [SerializeField] Vector3Int vecTile;
    [SerializeField] Vector3Int vecTile1;
    [SerializeField] int intRangeCheck;
    [SerializeField] TileBase tile, tile1;
    [SerializeField] Vector3 vecCurrentPos;
    [SerializeField] float fltOffestToCentre;
    [SerializeField] float fltDistanceStartOutRay;
    [SerializeField] Vector3 vecFollowthroughTmp;
    [SerializeField] Vector3 vecTmp;
    [SerializeField] float fltFollowThrough = 0.4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
       vecCurrentPos = transform.position;
        vecCurrentPos.y += fltOffestToCentre;
        
        vecTile = tilFog.WorldToCell(vecCurrentPos);

        tile = tilFog.GetTile(vecTile);

        /* if(tile != null)
         {
             Debug.Log("Tile " + vecTile + " is there");

             tile = null;


         }

         Debug.Log("Nothing at  " + vecTile);
 */

        for (int i = -intRangeCheck; i < intRangeCheck; i++)
        {
            for (int j = -intRangeCheck; j < intRangeCheck; j++)
            {
                vecTile1 = vecTile + new Vector3Int(i, j, 0);
                tile1 = tilFog.GetTile(vecTile1);

                if (tile1 != null)
                {

                 //   Debug.Log("Remove tile:" + vecTile1 + " at " + i + " , " + j);

                    tilFog.SetTile(vecTile1, null);
                }

                else
                {
                 //   Debug.Log("Nothing at" + tile1 + " at " + i + " , " + j);

                }

            }

            





        }

        for (int i = 0; i < 36  ; i++)
        {
            vecTmp = Vector3.up;
            vecTmp =  Quaternion.Euler( new Vector3(0, 0,i * 10) ) * vecTmp;



            RaycastHit2D hit = Physics2D.Raycast(vecCurrentPos+  vecTmp.normalized * fltDistanceStartOutRay, vecTmp.normalized, 1000);

         //   Debug.Log("Raycast to find tiles" + vecTmp);
          //  Debug.Log("raycast to find tile hit " + hit.collider.name +" with tag " + hit.collider.tag);
           // Debug.DrawRay(vecCurrentPos + vecTmp.normalized, vecTmp.normalized,Color.cyan,1000);
         //   Debug.DrawLine(vecCurrentPos + vecTmp.normalized*fltDistanceStartOutRay, hit.point, Color.green);


 vecFollowthroughTmp = new Vector3(hit.point.x, hit.point.y, 0) + vecTmp.normalized * fltFollowThrough;
        //    Debug.DrawLine(hit.point, vecFollowthroughTmp, Color.red);
           



            if (hit.collider.tag == "Tile" )
            {
              
                vecTile = tilFog.WorldToCell(hit.point);

                if (vecTile != null)
                {

                    tilFog.SetTile(vecTile, null);

             //       Debug.Log("Remove " + vecTile);

                }


                vecTile = tilFog.WorldToCell(vecFollowthroughTmp);

                if (vecTile != null)
                {

                    tilFog.SetTile(vecTile, null);

             //       Debug.Log("Remove " +vecTile);

                }
               



            }
            else
            {
                vecFollowthroughTmp = new Vector3(hit.point.x, hit.point.y, 0) + vecTmp.normalized * .4f;
               

                vecTile = tilFog.WorldToCell(vecFollowthroughTmp);

                if (vecTile != null)
                {

                    tilFog.SetTile(vecTile, null);

             //       Debug.Log("Remove " + vecTile);

                }

            }

        }


    }
}
