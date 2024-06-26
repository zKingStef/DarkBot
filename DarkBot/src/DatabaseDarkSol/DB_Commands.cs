using DarkBot.src.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkBot.src.DatabaseDarkSol
{
    public class DB_Commands
    {
        public string connectionString = "Host=bunjwqxejjdivx62llgi-postgresql.services.clever-cloud.com;" +
                                         "Username=ugaseupaiagerifnbppr;" +
                                         "Password=7BnA9hzCfoL46bt5W0n8Cf4jp80DKJ;" +
                                         "Database=bunjwqxejjdivx62llgi";


        // -- Example of Insert in Sales Table 
        //
        // INSERT INTO bmocfdpnmiqmcbuykudg.SALES
        // (SALES_Id, ART_Nr, CUS_Id, SALES_Price, SALES_Profit, PLAT_Id, PAYMENT_Id, SALES_Desc, SALES_GenDate, SALES_ModDate)
        // VALUES(208, 7, 29, 55, 5, 2, 1, 'TestArtikel - Discord', now(), now());
        
    }
}
