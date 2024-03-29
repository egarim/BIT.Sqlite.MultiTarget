﻿using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Xpo.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace BIT.Sqlite.Test
{
    public static class XpoHelper
    {
        static readonly Type[] entityTypes = new Type[] {
            typeof(Item)
        };
        public static void InitXpo(string connectionString)
        {
            var dictionary = PrepareDictionary();

            if (XpoDefault.DataLayer == null)
            {
                using (var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema))
                {
                    updateDataLayer.UpdateSchema(false, dictionary.CollectClassInfos(entityTypes));
                    UnitOfWork UoW = new UnitOfWork(updateDataLayer);
                    UoW.CreateObjectTypeRecords();
                }
            }

            var dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
            XpoDefault.Session = null;

            CreateDemoData();
        }
        public static UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
        static XPDictionary PrepareDictionary()
        {
            var dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(entityTypes);
            return dict;
        }

       
        static void CreateDemoData()
        {
            using (var uow = CreateUnitOfWork())
            {
                if (!uow.Query<Item>().Any())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var demoItem = new Item(uow);
                        demoItem.Description = $"item {i}";
                        
                    }
                    uow.CommitChanges();
                }
            }
        }
    }
}