﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.DAO;
using System.Windows.Forms;

namespace BACKEND
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
