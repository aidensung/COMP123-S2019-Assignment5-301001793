﻿using COMP123_S2019_Assignment5_301001793.Models;
using COMP123_S2019_Assignment5_301001793.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Student Name: Ilhyo Sung
 * Student ID: 301001793
 * Description: This is Main Program class
 */

namespace COMP123_S2019_Assignment5_301001793
{
    static class Program
    {
        public static Dictionary<FormName, Form> Forms;
        public static Product product;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // instantiate all forms here
            Forms = new Dictionary<FormName, Form>();
            Forms.Add(FormName.SPLASH_SCREEN, new SplashScreen());
            Forms.Add(FormName.START_FORM, new StartForm());
            Forms.Add(FormName.SELECT_FORM, new SelectForm());
            Forms.Add(FormName.PRODUCT_INFO_FORM, new ProductInfoForm());
            Forms.Add(FormName.ORDER_FORM, new OrderForm());
            Forms.Add(FormName.ABOUT_FORM, new AboutForm());

            // This is data container
            product = new Product();

            Application.Run(Forms[FormName.SPLASH_SCREEN]);
        }
    }
}
