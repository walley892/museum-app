var path = require('path');

module.exports = {
	getFile: getFile,
	getResponse: getResponse
}


function getFile(express, app) {

	app.get('/getModelFiles', function(req, res) {


		ans = "ok";

		var promise = new Promise(function(resolve, reject) {

				let response = getResponse(ans);
				resolve(response);
		});

		promise.then(function(value) {
			res.send(value);
			// expected output: "foo"
		});
	});
}

function getResponse(ans) {

	return {'status' : ans};
}
