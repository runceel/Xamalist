﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Xamalist
{
    public class AppDataService : IAppDataService
    {
        public AppDataService(IMobileServiceClient client)
        {
            // サーバから AppData のデータを取るための IMobileServiceTable を作成
            this.appDataTable = client.GetTable<AppData>();
        }

        private IMobileServiceTable<AppData> appDataTable;

		// Azure Mobile Apps から、データを全件(max50)取ってくる
        public async Task<IEnumerable<AppData>> GetAllAppDatasAsync()
        {
            return await this.appDataTable.CreateQuery().ToEnumerableAsync();
        }

		// Azure Mobile Apps から、データを 1件だけ取ってくる
		public Task<AppData> GetAppDataAsync(string id)
		{
			return this.appDataTable.LookupAsync(id);
		}
	}
}
