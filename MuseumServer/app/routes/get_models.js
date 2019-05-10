var path = require('path');
var database = require('../model/database')


module.exports = function(express, app) {

    app.get('/getModels', function(req, res) {
        let promise = new Promise(function(resolve, reject) {

            database.connect(function (client, collection) {
                database.getArtifacts(client, collection, function (response) {
                    resolve(response);
                });

            });
        });

        promise.then(function(value) {
            res.json(value);
            // expected output: "foo"
        });
    });
};