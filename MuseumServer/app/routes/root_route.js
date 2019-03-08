var path = require('path');
var cookieParser = require('cookie-parser');

module.exports = function(express, app) {
	app.use(cookieParser());

	app.get('/', function(req, res) {
		res.json({"status" : "ok"});
	});
};