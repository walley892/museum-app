var path = require('path');

module.exports = function(express, app) {

    app.get('/getModelFiles', function(req, res) {
        res.json({"status" : "ok"});
    });
};