using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace DatasourceLayer
{
    public class MongoCRUD
    {
        private IMongoDatabase Db;
        public MongoCRUD(string database)
        {
            var _client = new MongoClient();
            Db = _client.GetDatabase(database);

        }

        public void InsertRecord<T>(string Table, T Record)
        {
            var _collection = Db.GetCollection<T>(Table);
            _collection.InsertOne(Record);
        }

        public List<T> LoadRecords<T>(string Table)
        {
            var _collection = Db.GetCollection<T>(Table);

            return _collection.Find(new BsonDocument()).ToList();

        }

        public T LoadRecordById<T>(string Table, Guid Id)
        {
            var _collection = Db.GetCollection<T>(Table);
            var filter = Builders<T>.Filter.Eq("Id", Id);
            var _outputRec = _collection.Find(filter).First();
            return _outputRec;
        }

        public void UpsertRecord<T>(string Table, Guid Id, T Record)
        {
            var _collection = Db.GetCollection<T>(Table);
            var _result = _collection.ReplaceOne(
                new BsonDocument("_id", Id),
                Record,
                new UpdateOptions { IsUpsert = true });


        }

        public void DeleteRecord<T>(string Table, Guid Id)
        {
            var _collection = Db.GetCollection<T>(Table);
            var filter = Builders<T>.Filter.Eq("Id", Id);
            _collection.DeleteOne(filter);

        }
    }
}