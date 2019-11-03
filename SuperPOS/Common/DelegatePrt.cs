using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.Common
{
    public delegate void DelegatePreview();

    public class DelegatePrt
    {
        private static EntityControl _control = new EntityControl();
        //private Action saveShowOrderModelPreview;

        //public DelegatePrt(Action saveShowOrderModelPreview)
        //{
        //    this.saveShowOrderModelPreview = saveShowOrderModelPreview;
        //}

        #region Show Order模板
        public static void SaveShowOrderModelPreview()
        {
            try
            {string content = @"";

                TaPreviewInfo taPreview = new TaPreviewInfo();

                foreach (var f in new DirectoryInfo(PrtStatic.PRT_TEMPLATE_FILE_PATH).GetFiles().Where(s => s.Name.Equals(@"showorder.txt")))
                {
                    if (f.Length > 0)
                    {
                        //switch (f.Name)
                        //{
                        //    case @"taKitchen.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_KITCHEN_PRE;
                        //        break;
                        //    case @"taReceipt.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_RECEIPT_PRE;
                        //        break;
                        //    case @"taBill.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_BILL_PRE;
                        //        break;
                        //    case @"ta.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_ALL_PRE;
                        //        break;
                        //    case @"showorder.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;
                        //        break;
                        //}
                        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;

                        taPreview.PreviewFileName = f.Name;
                        StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + f.Name, Encoding.UTF8);
                        taPreview.PreviewContent = objReader.ReadToEnd();
                        taPreview.PreviewContent = PrtTemplate.ReplacePrtKeysPreviewDefaultContent(taPreview.PreviewContent);
                        
                        var lstTaPreview = CommonData.TaPreview.Where(s => s.PreviewType.Equals(taPreview.PreviewType));

                        if (lstTaPreview.Any())
                        {
                            taPreview.ID = lstTaPreview.FirstOrDefault(s => s.PreviewType.Equals(taPreview.PreviewType)).ID;
                            _control.UpdateEntity(taPreview);
                        }
                        else
                        {
                            _control.AddEntity(taPreview);
                        }
                    }
                }
            }
            catch (Exception ex) { LogHelper.Error(@"CommonDAL", ex); }
        }
        #endregion
    }
}
