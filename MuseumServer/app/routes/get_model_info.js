var path = require('path');
var database = require('../model/database')

module.exports = {
	getInfo: getInfo
};


function getInfo(express, app) {

	app.get('/getModelInfo', function(req, res) {


		let artifact_id = req.query.artifact_id;

		var promise = new Promise(function(resolve, reject) {

			database.connect(function (client, collection) {
				database.getArtifact(client, collection, artifact_id, function (response) {
					resolve(response);
				});

			});
		});

		promise.then(function(value) {
			res.json(value);
			// expected output: "foo"
		});
	});

}