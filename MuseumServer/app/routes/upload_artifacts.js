var path = require('path');

module.exports = function(express, app) {

    app.get('/uploadArtifacts', function(req, res) {
        res.json({"status" : "ok"});
    });
};