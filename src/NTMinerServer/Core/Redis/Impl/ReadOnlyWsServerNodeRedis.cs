﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTMiner.Core.Redis.Impl {
    public class ReadOnlyWsServerNodeRedis : IReadOnlyWsServerNodeRedis {
        protected const string _redisKeyWsServerNodeByAddress = "wsServerNodes.WsServerNodeByAddress";// 根据Address索引WsServerNodeState对象的json
        protected const string _redisKeyWsServerNodeAddress = "wsServerNodes.Address";

        protected readonly IServerConnection _serverConnection;
        public ReadOnlyWsServerNodeRedis(IServerConnection serverConnection) {
            _serverConnection = serverConnection;
        }

        public Task<Dictionary<string, DateTime>> GetAllAddress() {
            var db = _serverConnection.RedisConn.GetDatabase();
            return db.HashGetAllAsync(_redisKeyWsServerNodeAddress).ContinueWith(t => {
                Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
                foreach (var item in t.Result) {
                    if (item.Value.HasValue && DateTime.TryParse(item.Value, out DateTime activeOn)) {
                        dic.Add(item.Name, activeOn);
                    }
                }
                return dic;
            });
        }
    }
}
