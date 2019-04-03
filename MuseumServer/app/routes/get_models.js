var path = require('path');

module.exports = function(express, app) {

    app.get('/getModels', function(req, res) {
        res.json({"status" : "ok"});
    });
};