const path = require('path');
const formidable = require('formidable');

module.exports = function(express, app) {

    app.post('/uploadArtifacts', function(req, res) {
        const form = new formidable.IncomingForm();

        form.parse(req);

        form.on('fileBegin', function (name, file){
            file.path = __dirname + '/uploads/' + file.name;
        });

        form.on('file', function (name, file){
            console.log('Uploaded ' + file.name);
        });

        res.json({"status" : "ok"});
    });

};