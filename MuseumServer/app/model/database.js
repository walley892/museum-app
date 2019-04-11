const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');

var mongourl = process.env.MONGO_URL;

// Database Name
const dbName = 'museum-app';


module.exports = {
    connect: connect,
    addArtifact: addArtifact
};




function connect(callback) {

    const client = new MongoClient(mongourl, { useNewUrlParser: true });
    client.connect(err => {
        if(err) {
            console.log(err);
        }
        else {
            const collection = client.db("museum-app").collection("artifacts");
            // perform actions on the collection object

            callback(client, collection);
        }
    });

}

function addArtifact(client, collection, artifact, callback) {
    collection.updateOne(
        { name:  artifact.name},
        { $set: artifact },
        { upsert: true },
        function (err, document) {
            collection.findOne({name: artifact.name}, function (err, response) {
                let id = response._id.toHexString();
                callback(id);
                endConnection(client);
            })
        }
    );
}

function endConnection(client) {
    client.close();
}