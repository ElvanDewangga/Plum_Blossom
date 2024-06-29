using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GetComponentByName
{
    public Type On_Get_Name(string typeName)
    {
        // Tentukan nama lengkap dari tipe yang akan dicari, termasuk namespace jika diperlukan
        // string fullTypeName = "NamespaceName." + typeName;
        string fullTypeName= typeName;
        // Dapatkan Type dari string
        System.Type type = System.Type.GetType(fullTypeName);

        if (type != null)
        {
            // Gunakan GetComponent dengan tipe yang telah didapatkan
            return  type;
        }

        return null;
    }
}
