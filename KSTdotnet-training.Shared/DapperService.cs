﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace KSTdotnet_training.Shared
{
    public class DapperService
    {
        private readonly String _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;

        }

        public List<T> Query<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var list = db.Query<T>(query, param).ToList();

            return list;
        }

        public  T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var item = db.QueryFirstOrDefault<T>(query, param);

            return item;
        }


        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            int result = db.Execute(query, param);

            return result;
        }
    }
}
