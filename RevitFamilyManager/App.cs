#region Namespaces

using Autodesk.Revit.UI;
using RevitFamilyManager.Data;
using RevitFamilyManager.Properties;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;

#endregion Namespaces

namespace RevitFamilyManager
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(assemblyFolder, "FamilyData.xml");
            if (!File.Exists(xmlFileName))
            {
                XmlWriter writer = XmlWriter.Create(xmlFileName);
            }
            //DownloadDataBase();
            //Create ribbon tab
            string tabName = "族管理";
            a.CreateRibbonTab(tabName);

            #region Ribbon buttons

            //Create buttons
            string path = Assembly.GetExecutingAssembly().Location;

            //1 电气工具
            PushButtonData buttonElectricalFixture = new PushButtonData("Elektroinstallationen", "电气\n装置", path, "RevitFamilyManager.Families.ElectricalFixture")
            {
                ToolTip = "显示电气设备系列族",
                LargeImage = GetImage(Resources.Electroinstallation.GetHbitmap())
            };

            //2通讯-通讯设备
            PushButtonData buttonCommunication = new PushButtonData("通讯设备", "通讯\n设备", path, "RevitFamilyManager.Families.Communication")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Kommunication.GetHbitmap())
            };

            //3 数据设备
            PushButtonData buttonData = new PushButtonData("数据设备", "数据\n设备", path, "RevitFamilyManager.Families.Data")
            {
                ToolTip = "显示电话设备系列族",
                LargeImage = GetImage(Resources.Daten.GetHbitmap())
            };

            //4 火灾报警器
            PushButtonData buttonFireAlarm = new PushButtonData("火灾报警器", "火灾\n报警器", path, "RevitFamilyManager.Families.FireAlarm")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Brandmelder.GetHbitmap())
            };

            //5照明-电灯开关
            PushButtonData buttonLighting = new PushButtonData("电灯开关", "电气\n装置", path, "RevitFamilyManager.Families.Lighting")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Lichtschalter.GetHbitmap())
            };

            //5 灯具-灯
            PushButtonData buttonLightingFixtures = new PushButtonData("灯具", "照片\n设备", path, "RevitFamilyManager.Families.LightingFixture")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Leuchte.GetHbitmap())
            };

            //7 护士呼叫-紧急呼叫设备
            PushButtonData buttonNurseCall = new PushButtonData("紧急呼叫设备", "护理\n呼叫", path, "RevitFamilyManager.Families.NurceCall")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Notruf.GetHbitmap())
            };

            //8 安全-安全设备
            PushButtonData buttonSecurity = new PushButtonData("安全-安全设备", "安全\n设备", path, "RevitFamilyManager.Families.Security")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Sicherheit.GetHbitmap())
            };

            //9 电话-电话设备
            PushButtonData buttonPhone = new PushButtonData("电话设备", "电话\n设备", path, "RevitFamilyManager.Families.Phone")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Telefon.GetHbitmap())
            };

            //10 电气安装-电气设备
            PushButtonData buttonElectroinstallation = new PushButtonData("电气设备", "电气\n设备", path, "RevitFamilyManager.Families.Electroinstallation")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.ElektrischeAusstattung.GetHbitmap())
            };

            //11 注释-标题
            PushButtonData buttonAnnotation = new PushButtonData("标题", "注释\n记号", path, "RevitFamilyManager.Families.Descriptions")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Description.GetHbitmap())
            };

            //12 电缆桥架配件-空管配件
            PushButtonData buttonCableTrayFittings = new PushButtonData("电缆配件", "电缆桥架\n配件", path, "RevitFamilyManager.Families.CableTrayFitting")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Kabeltrassenformteil.GetHbitmap())
            };

            //13 接地
            PushButtonData buttonEarthing = new PushButtonData("接地线", "接地\n设备", path, "RevitFamilyManager.Families.Earthing")
            {
                ToolTip = "Shows earthing families",
                LargeImage = GetImage(Resources.Erdnung.GetHbitmap())
            };

            //14 通用模型-通用模型
            PushButtonData buttonGenericModels = new PushButtonData("通用模型", "常规\n模型", path, "RevitFamilyManager.Families.GenericModels")
            {
                ToolTip = "User Preferences",
                LargeImage = GetImage(Resources.GenericModels.GetHbitmap())
            };

            //15 图例
            PushButtonData buttonLegend = new PushButtonData("图例", "图例\n颜色填充", path, "RevitFamilyManager.Families.Legend")
            {
                ToolTip = "Legend families",
                LargeImage = GetImage(Resources.Legende.GetHbitmap())
            };

            //15 电缆桥架
            PushButtonData buttonCables = new PushButtonData("电缆桥架", "电缆\n桥架", path, "RevitFamilyManager.Families.CableTrays")
            {
                ToolTip = "Cable trays families",
                LargeImage = GetImage(Resources.Kabeltrasse.GetHbitmap())
            };

            //---------------------------------------------------------------------
            //14 Settings
            PushButtonData buttonSettings = new PushButtonData("Settings", "族\n文件夹", path, "RevitFamilyManager.UserSettings")
            {
                ToolTip = "User Preferences",
                LargeImage = GetImage(Resources.Settings.GetHbitmap())
            };

            //15 UpdateDB
            PushButtonData buttonUpdateDb = new PushButtonData("Update DB", "更新\n数据库", path, "RevitFamilyManager.Data.UpdateDB")
            {
                ToolTip = "UpdateDB",
                LargeImage = GetImage(Resources.UpdateDB.GetHbitmap())
            };

            //16 Create Type Projects ----/Developer tool for Web Application
            PushButtonData buttonCreateProjects = new PushButtonData("ProjectCreator", "创建\n项目", path, "RevitFamilyManager.Data.ProjectCreator")
            {
                ToolTip = "Create Projects From Family Type",
                LargeImage = GetImage(Resources.RevitLogo.GetHbitmap())
            };

            //Create ribbon panel
            RibbonPanel toolPanel = a.CreateRibbonPanel(tabName, "族类别");

            //Add buttons to panel
            toolPanel.AddItem(buttonElectricalFixture);
            toolPanel.AddItem(buttonElectroinstallation);
            toolPanel.AddItem(buttonCables);
            //电缆桥架配件
            toolPanel.AddItem(buttonCableTrayFittings);
            toolPanel.AddSeparator();

            toolPanel.AddItem(buttonLighting);
            toolPanel.AddItem(buttonLightingFixtures);
            toolPanel.AddSeparator();

            toolPanel.AddItem(buttonCommunication);
            toolPanel.AddItem(buttonData);
            toolPanel.AddItem(buttonPhone);
            toolPanel.AddSeparator();

            toolPanel.AddItem(buttonNurseCall);
            toolPanel.AddItem(buttonSecurity);
            toolPanel.AddItem(buttonFireAlarm);

            toolPanel.AddItem(buttonEarthing);

            toolPanel.AddSeparator();

            // toolPanel.AddItem(buttonCableTrayFittings);
            toolPanel.AddItem(buttonGenericModels);
            toolPanel.AddItem(buttonAnnotation);
            toolPanel.AddItem(buttonLegend);

            ///////////////////////////////////////////////
            //----Dev Tools---
            //////////////////////////////////////////////

            RibbonPanel settingsPanel = a.CreateRibbonPanel(tabName, "设置");
            settingsPanel.AddItem(buttonSettings);
            settingsPanel.AddItem(buttonUpdateDb);
            settingsPanel.AddItem(buttonCreateProjects);

            //////////////////////////////////////////////

            #endregion Ribbon buttons

            //Registering Docking panel
            SingleInstallEvent handler = new SingleInstallEvent();
            ExternalEvent exEvent = ExternalEvent.Create(handler);
            FamilyManagerDockable dock = new FamilyManagerDockable(exEvent, handler);
            //new FamilyManagerDockable();
            FamilyManagerDockable.WPFpanel = dock;

            DockablePaneProviderData data = new DockablePaneProviderData();
            dock.SetupDockablePane(data);

            DockablePaneId dpId = new DockablePaneId(new Guid("209923d1-7cdc-4a1c-a4ad-1e2f9aae1dc5"));
            a.RegisterDockablePane(dpId, "Familien Manager", dock);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        private static BitmapSource GetImage(IntPtr bm)
        {
            BitmapSource bmSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bm,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bmSource;
        }

        private void DownloadDataBase()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(path, "FamilyData.xml");

            string link =
                @"https://forgefiles.blob.core.windows.net/forgefiles/FamilyData.xml";
            using (var client = new WebClient())
            {
                client.DownloadFile(link, xmlFileName);
            }
        }
    }
}