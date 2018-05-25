﻿using Autodesk.Revit.UI;
using RevitFamilyManager.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Autodesk.Revit.DB;

namespace RevitFamilyManager
{
    class FamilyFolderProcess
    {
        public string GetDeviceFolder(string deviceType)
        {
            UserSettings userSettings = new UserSettings();
            if (string.IsNullOrEmpty(Properties.Settings.Default.RootFolder))
            {
                userSettings.GetStartFolder();
            }
            string[] allPaths = Directory.GetDirectories(Properties.Settings.Default.RootFolder);
            string path = string.Empty;
            foreach (string folder in allPaths)
            {
                if (folder.Contains(deviceType))
                {
                    path = folder;
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                TaskDialog.Show("Warning", "Folder \"" + deviceType + "\" not found");
            }
            return path;
        }

        public List<FamilyData> GetFamilyData(string path)
        {
            List<FamilyData> familyDataList = new List<FamilyData>();
            foreach (string file in Directory.GetFiles(path))
            {
                if (FileIsFamilyType(file))
                {
                    FamilyData familyItem = new FamilyData();
                    familyItem.Category = FamilyCategoryCut(file);
                    familyItem.FamilyPath = file;
                    familyItem.FamilyName = FileNameCut(file);
                    familyDataList.Add(familyItem);
                }
            }
            return familyDataList;
        }

        private string FamilyCategoryCut(string file)
        {
            int lastSlash = file.LastIndexOf("\\", StringComparison.Ordinal);
            string category = file.Substring(0, lastSlash);
            lastSlash = category.LastIndexOf("\\", StringComparison.Ordinal);
            category = category.Substring(lastSlash+1);
            return category;
        }

        private string FileNameCut(string file)
        {
            int lastSlash = file.LastIndexOf("\\", StringComparison.Ordinal);
            int lastDot = file.LastIndexOf(".", StringComparison.Ordinal);
            string fileName = file.Substring(++lastSlash, lastDot - lastSlash);
            return fileName;
        }

        private bool FileIsFamilyType(string file)
        {
            int lastDot = file.LastIndexOf(".", StringComparison.Ordinal);
            string fileType = file.Substring(lastDot);
            return fileType.Contains("rfa");
        }

        private List<FamilyData> ReadXML()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(path, "FamilyData.xml");
            
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;

            XmlSerializer serializer = new XmlSerializer(typeof(List<FamilyData>));
            FileStream fs = new FileStream(xmlFileName, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs, settings);

            var familyList = (List<FamilyData>)serializer.Deserialize(reader);
            fs.Close();
            string pathDll = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            pathDll = pathDll.Substring(0, pathDll.Length - 4);
            //TODO
           
            foreach (var item in familyList)
            {
                if (item != null)
                {
                    int index = item.FamilyPath.IndexOf("HHM");
                    item.FamilyPath = item.FamilyPath.Substring(index);
                    item.FamilyPath = Path.Combine(pathDll, item.FamilyPath);
                    //MessageBox.Show(item.FamilyPath);
                    //-----------------------------------------------------------------------TODO
                }
            }
            return familyList;
        }

        public List<FamilyData> GetCategoryTypes(string categoryName)
        {
            List<FamilyData> filteredList = new List<FamilyData>();
            foreach (var item in ReadXML())
            {
                if (item == null) continue;
                if (item.Category == categoryName)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }


    }
}

