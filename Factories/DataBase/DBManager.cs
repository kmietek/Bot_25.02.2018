using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Enums;

namespace Factories.DataBase
{
    public class DBManager
    {
        public static void StartDBProcesses(Dictionary<EnumPages, List<AncillaryAbstractClass>> slownik)    //todo nie dopuścić do kilki wpisów z tej samej factoy classes
        {
            foreach (var kfp in slownik)    //all
            {
                string table_name = "";
                string columns = "";
                string values = "";
                string query;
                if (kfp.Value != null)
                {
                    foreach (AncillaryAbstractClass item in kfp.Value)      // list of AncillaryAbstractClass
                    {
                        Type myType = item.GetType();
                        var props = myType.GetFields(BindingFlags.Instance | BindingFlags.Public);      //get instance of AncillaryAbstractClass

                        table_name = myType.Name.ToLower() + "Table";

                        for (int i = 0; i < props.Length; i++)                                          // get fields of instance
                        {
                            string name = props[i].Name;
                            string value = props[i].GetValue(item).ToString();
                            if (i != props.Length - 1)
                            {
                                columns += name + ",";
                                values += "'" + value + "' ,";
                            }
                            if (i == props.Length - 1)
                            {
                                columns += name;
                                values += "'" + value + "'";
                            }

                        }
                    }
                    query = String.Format("INSERT INTO {0} ({1}) VALUES({2}); ", table_name, columns, values);
                }
            }
        }

    }
}