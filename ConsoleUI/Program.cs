using System.IO;
using Newtonsoft.Json;

await DataBaseClient.PlayerCollection.DeleteManyAsync(
    Builders<Player>.Filter.Exists(x => x.Id)
);