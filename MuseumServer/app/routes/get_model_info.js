var path = require('path');

module.exports = function(express, app) {

    app.get('/getModelInfo', function(req, res) {
        res.json({"status" : "ok"});
    });
};