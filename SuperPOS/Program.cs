using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using SuperPOS.Common;

namespace SuperPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //bool IsNewApp;

            //using (new Mutex(true, Application.ProductName, out IsNewApp))
            //{
            //    if (IsNewApp)
            //    {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    BonusSkins.Register();
                    SkinManager.EnableFormSkins();
                    UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

                    try
                    {
                        FrmInit frmInit = new FrmInit();
                        if (DialogResult.Cancel == frmInit.ShowDialog()) return;
                        frmInit.Dispose();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error("Init Error", ex);
                        throw;
                    }
                //}
                //else
                //{
                //    MessageBox.Show(PubComm.START_ONLY_ONE_APP);
                //}
            //}
            //Application.Run(new FrmInit());
        }
    }
}
