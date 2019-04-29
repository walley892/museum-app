const MongoClient = require('mongodb').MongoClient;
const ObjectID = require('mongodb').ObjectID;
const assert = require('assert');

var mongourl = process.env.MONGO_URL;

// Database Name
const dbName = 'museum-app';


module.exports = {
    connect: connect,
    addArtifact: addArtifact,
    getArtifact: getArtifact,
    getArtifacts: getArtifacts
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


function getArtifact(client, collection, artifact_id, callback) {
    var objectId = new ObjectID.createFromHexString(artifact_id);

    let returnVal = {found : false};

    collection.findOne(
        { _id:  objectId},
        function (err, document) {

            if(!err) {
                returnVal.found = true;
                returnVal.document = document;
            }
            endConnection(client);
            callback(returnVal);
        }
    );
}

function getArtifacts(client, collection, callback) {

    let returnVal = {found : false};

    collection.find({}).toArray(
        function (err, documents) {

            if(!err) {
                returnVal.found = true;
                returnVal.documents = documents;
            }
            endConnection(client);
            callback(returnVal);
        }
    );
}

function endConnection(client) {
    client.close();
}