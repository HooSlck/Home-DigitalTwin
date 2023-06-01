using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using Unity.VisualScripting;
using UnityEngine.Windows;
using System.Net;

public class GameManager : MonoBehaviour
{         
    // Start is called before the first frame update
    void Start()
    {
        string strConn = string.Format("server={0};uid={1};pwd={2};database={3};charset=utf8 ;","db-iotsensor.cnxlrxm4unpk.us-west-2.rds.amazonaws.com" , "admin", "cap991204", "innodb");
        string quary = "SELECT * FROM dht_data";
        MySqlConnection conn = new MySqlConnection(strConn);
        conn.Open();

        MySqlCommand command = new MySqlCommand(quary, conn);
        MySqlDataReader rdr = command.ExecuteReader();

        string temp = string.Empty;
        if (rdr == null) temp = "No return";
        else
        {
            while (rdr.Read())
            {
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    if (i != rdr.FieldCount - 1)
                        temp += rdr[i] + ";";    // parser 넣어주기
                    else if (i == rdr.FieldCount - 1)
                        temp += rdr[i] + "\n";
                }
            }
            Debug.Log(temp);
        }

        conn.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
