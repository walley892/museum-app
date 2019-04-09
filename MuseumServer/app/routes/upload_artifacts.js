const path = require('path');
const formidable = require('formidable');
const upload = require('../model/upload');

const basePath = __dirname + "/../../uploads/v1/";

module.exports = function(express, app) {

    app.post('/uploadArtifacts', function(req, res) {
        let artifactName = "test";
        let artifactDescription = "test";

        var form = new formidable.IncomingForm();

        form.parse(req);


        form.on('field', (name, field) => {
                console.log('Field', name, field);
                if(name=="artifactName")
                    xartifactName = field;
                else if(name=="artifactDescription") {
                    artifactDescription = field;
                }
        });

        form.on('fileBegin', (name, file) => {

                let path;
                let __dir_name = "../"

                if(name=="model") {
                    path = basePath + 'models/' + file.name.toString();
                }
                else if(name=="texture") {
                    path = basePath + 'textures/' + file.name.toString();
                }

                upload.ensureDirectoryExistence(path);
                file.path = path;
            })

        form.on('file', (name, file) => {
                console.log('Uploaded file', name, file)
            })
            .on('aborted', () => {
                console.error('Request aborted by the user')
            })
            .on('error', (err) => {
                console.error('Error', err)
                throw err
            })
            .on('end', () => {
                res.end()
            })
    });

};