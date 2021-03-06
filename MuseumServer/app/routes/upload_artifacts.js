const path = require('path');
const formidable = require('formidable');
const upload = require('../model/upload');
const database = require('../model/database');
const qrcode = require('qrcode-generator');

const basePath = path.join(__dirname, "/../uploads"); //process.env.FILE_HOME;
const fileVersion = "/v1/";

module.exports = function(express, app) {

    app.post('/uploadArtifacts', function(req, res) {

        app.set("view engine", "pug");

        app.set("views", path.join(__dirname, '/../views'));

        let artifact = {
            name : "test",
            description : "test",
            modelPath : "test",
            texturePath : "test",
            };

        var form = new formidable.IncomingForm();

        form.parse(req);


        form.on('field', (name, field) => {
                console.log('Field', name, field);
                if(name=="artifactName")
                    artifact.name = field;
                else if(name=="artifactDescription") {
                    artifact.description = field;
                }
        }).on('fileBegin', (name, file) => {

                let path;

                if(name=="model") {
                    artifact.modelPath = fileVersion + 'models/' + file.name.toString();
                    path = basePath + artifact.modelPath;
                }
                else if(name=="texture") {
                    artifact.texturePath = fileVersion + 'textures/' + file.name.toString();
                    path = basePath + artifact.texturePath;
                }

                upload.ensureDirectoryExistence(path);
                file.path = path;
            }).on('file', (name, file) => {
                console.log('Uploaded file', name, file)
            })
            .on('aborted', () => {
                console.error('Request aborted by the user')
            })
            .on('error', (err) => {
                console.error('Error', err);
                throw err
            });


            form.on('end', () => {
                database.connect(function (client, collection) {
                    database.addArtifact(client, collection, artifact, function (id) {

                        generateQR(id, function (url) {
                            res.render("uploaded", {
                                data_url: url
                            });
                        });
                    });
                });
            })
    });


    function processArtifact() {

    }

    function generateQR(id, callback) {
        let typeNumber = 0;
        let errorCorrectionLevel = 'M';
        let qr = qrcode(typeNumber, errorCorrectionLevel);
        qr.addData(id);
        qr.make();

        console.log("Uploaded artifact id: " + id)

        callback(qr.createDataURL(15));
    }

};