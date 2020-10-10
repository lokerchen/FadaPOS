using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.Print
{
    public class WbPrtCommon
    {
        #region 获得打印基本信息
        /// <summary>
        /// 获得打印基本信息
        /// </summary>
        /// <returns>打印基本信息</returns>
        public static TaSysPrtSetGeneralInfo GetTaSysPrtSetupGeneral()
        {
            TaSysPrtSetGeneralInfo taSysPrtSetGeneral;

            try
            {
                new SystemData().GetTaSysPrtSetGeneral();

                var lstGen = CommonData.TaSysPrtSetGeneral;

                taSysPrtSetGeneral = lstGen.Any() ? lstGen.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtCommon/GetSysPrtSetupGeneral", ex);
                return null;
            }

            return taSysPrtSetGeneral;
        }
        #endregion

        #region 获得Counter Setting 1信息
        /// <summary>
        /// 获得Counter Setting 1信息
        /// </summary>
        /// <returns>Counter Setting 1信息</returns>
        public static TaSysPrtSetCounterSetting1Info GetTaTaSysPrtSetCounterSetting1()
        {
            TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1;

            try
            {
                new SystemData().GetTaSysPrtSetCountSetting1();

                var lstCs1 = CommonData.TaSysPrtSetCounterSetting1;

                taSysPrtSetCounterSetting1 = lstCs1.Any() ? lstCs1.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtCommon/GetTaTaSysPrtSetCounterSetting1", ex);
                return null;
            }

            return taSysPrtSetCounterSetting1;
        }
        #endregion

        #region 获得Counter Setting 2信息
        /// <summary>
        /// 获得Counter Setting 2信息
        /// </summary>
        /// <returns>Counter Setting 2信息</returns>
        public static TaSysPrtSetCounterSetting2Info GetTaTaSysPrtSetCounterSetting2()
        {
            TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2;

            try
            {
                new SystemData().GetTaSysPrtSetCountSetting2();

                var lstCs2 = CommonData.TaSysPrtSetCounterSetting2;

                taSysPrtSetCounterSetting2 = lstCs2.Any() ? lstCs2.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtCommon/GetTaTaSysPrtSetCounterSetting2", ex);
                return null;
            }

            return taSysPrtSetCounterSetting2;
        }
        #endregion

        #region 获得打印Kitchen信息
        /// <summary>
        /// 获得打印Kitchen信息
        /// </summary>
        /// <returns>打印Kitchen信息</returns>
        public static TaSysPrtSetKitchenInfo GetTaSysPrtSetKitchen()
        {
            TaSysPrtSetKitchenInfo taSysPrtSetKitchen;

            try
            {
                new SystemData().GetTaSysPrtSetKitchen();

                var lstKit = CommonData.TaSysPrtSetKitchen;

                taSysPrtSetKitchen = lstKit.Any() ? lstKit.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtCommon/GetTaSysPrtSetKitchen", ex);
                return null;
            }

            return taSysPrtSetKitchen;
        }
        #endregion
    }
}
