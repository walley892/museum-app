var path = require('path');

module.exports = {
	route: route,
	getResponse: getResponse
}


function route(express, app) {

	app.get('/', function(req, res) {
		app.use( express.static( __dirname + '/../pages/upload' ));
		res.sendFile( path.join( __dirname, '/../pages/upload', 'upload.html' ));
	});
}

function getResponse(ans) {

	return {'status' : ans};
}