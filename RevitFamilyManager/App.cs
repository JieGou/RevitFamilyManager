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
            string tabName = "�����";
            a.CreateRibbonTab(tabName);

            #region Ribbon buttons

            //Create buttons
            string path = Assembly.GetExecutingAssembly().Location;

            //1 ��������
            PushButtonData buttonElectricalFixture = new PushButtonData("Elektroinstallationen", "����\nװ��", path, "RevitFamilyManager.Families.ElectricalFixture")
            {
                ToolTip = "��ʾ�����豸ϵ����",
                LargeImage = GetImage(Resources.Electroinstallation.GetHbitmap())
            };

            //2ͨѶ-ͨѶ�豸
            PushButtonData buttonCommunication = new PushButtonData("ͨѶ�豸", "ͨѶ\n�豸", path, "RevitFamilyManager.Families.Communication")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Kommunication.GetHbitmap())
            };

            //3 �����豸
            PushButtonData buttonData = new PushButtonData("�����豸", "����\n�豸", path, "RevitFamilyManager.Families.Data")
            {
                ToolTip = "��ʾ�绰�豸ϵ����",
                LargeImage = GetImage(Resources.Daten.GetHbitmap())
            };

            //4 ���ֱ�����
            PushButtonData buttonFireAlarm = new PushButtonData("���ֱ�����", "����\n������", path, "RevitFamilyManager.Families.FireAlarm")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Brandmelder.GetHbitmap())
            };

            //5����-��ƿ���
            PushButtonData buttonLighting = new PushButtonData("��ƿ���", "����\nװ��", path, "RevitFamilyManager.Families.Lighting")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Lichtschalter.GetHbitmap())
            };

            //5 �ƾ�-��
            PushButtonData buttonLightingFixtures = new PushButtonData("�ƾ�", "��Ƭ\n�豸", path, "RevitFamilyManager.Families.LightingFixture")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Leuchte.GetHbitmap())
            };

            //7 ��ʿ����-���������豸
            PushButtonData buttonNurseCall = new PushButtonData("���������豸", "����\n����", path, "RevitFamilyManager.Families.NurceCall")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Notruf.GetHbitmap())
            };

            //8 ��ȫ-��ȫ�豸
            PushButtonData buttonSecurity = new PushButtonData("��ȫ-��ȫ�豸", "��ȫ\n�豸", path, "RevitFamilyManager.Families.Security")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Sicherheit.GetHbitmap())
            };

            //9 �绰-�绰�豸
            PushButtonData buttonPhone = new PushButtonData("�绰�豸", "�绰\n�豸", path, "RevitFamilyManager.Families.Phone")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Telefon.GetHbitmap())
            };

            //10 ������װ-�����豸
            PushButtonData buttonElectroinstallation = new PushButtonData("�����豸", "����\n�豸", path, "RevitFamilyManager.Families.Electroinstallation")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.ElektrischeAusstattung.GetHbitmap())
            };

            //11 ע��-����
            PushButtonData buttonAnnotation = new PushButtonData("����", "ע��\n�Ǻ�", path, "RevitFamilyManager.Families.Descriptions")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Description.GetHbitmap())
            };

            //12 �����ż����-�չ����
            PushButtonData buttonCableTrayFittings = new PushButtonData("�������", "�����ż�\n���", path, "RevitFamilyManager.Families.CableTrayFitting")
            {
                ToolTip = "Shows telephon devices families",
                LargeImage = GetImage(Resources.Kabeltrassenformteil.GetHbitmap())
            };

            //13 �ӵ�
            PushButtonData buttonEarthing = new PushButtonData("�ӵ���", "�ӵ�\n�豸", path, "RevitFamilyManager.Families.Earthing")
            {
                ToolTip = "Shows earthing families",
                LargeImage = GetImage(Resources.Erdnung.GetHbitmap())
            };

            //14 ͨ��ģ��-ͨ��ģ��
            PushButtonData buttonGenericModels = new PushButtonData("ͨ��ģ��", "����\nģ��", path, "RevitFamilyManager.Families.GenericModels")
            {
                ToolTip = "User Preferences",
                LargeImage = GetImage(Resources.GenericModels.GetHbitmap())
            };

            //15 ͼ��
            PushButtonData buttonLegend = new PushButtonData("ͼ��", "ͼ��\n��ɫ���", path, "RevitFamilyManager.Families.Legend")
            {
                ToolTip = "Legend families",
                LargeImage = GetImage(Resources.Legende.GetHbitmap())
            };

            //15 �����ż�
            PushButtonData buttonCables = new PushButtonData("�����ż�", "����\n�ż�", path, "RevitFamilyManager.Families.CableTrays")
            {
                ToolTip = "Cable trays families",
                LargeImage = GetImage(Resources.Kabeltrasse.GetHbitmap())
            };

            //---------------------------------------------------------------------
            //14 Settings
            PushButtonData buttonSettings = new PushButtonData("Settings", "��\n�ļ���", path, "RevitFamilyManager.UserSettings")
            {
                ToolTip = "User Preferences",
                LargeImage = GetImage(Resources.Settings.GetHbitmap())
            };

            //15 UpdateDB
            PushButtonData buttonUpdateDb = new PushButtonData("Update DB", "����\n���ݿ�", path, "RevitFamilyManager.Data.UpdateDB")
            {
                ToolTip = "UpdateDB",
                LargeImage = GetImage(Resources.UpdateDB.GetHbitmap())
            };

            //16 Create Type Projects ----/Developer tool for Web Application
            PushButtonData buttonCreateProjects = new PushButtonData("ProjectCreator", "����\n��Ŀ", path, "RevitFamilyManager.Data.ProjectCreator")
            {
                ToolTip = "Create Projects From Family Type",
                LargeImage = GetImage(Resources.RevitLogo.GetHbitmap())
            };

            //Create ribbon panel
            RibbonPanel toolPanel = a.CreateRibbonPanel(tabName, "�����");

            //Add buttons to panel
            toolPanel.AddItem(buttonElectricalFixture);
            toolPanel.AddItem(buttonElectroinstallation);
            toolPanel.AddItem(buttonCables);
            //�����ż����
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

            RibbonPanel settingsPanel = a.CreateRibbonPanel(tabName, "����");
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