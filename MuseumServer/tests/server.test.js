// const request = require('request');
// const database = require('../app/model/database');
// const fs = require('fs');



const request = require('supertest');
const app = require('../app');


describe('Test the root path', () => {
    test('It should respond to the GET method', (done) => {
        request(app).get('/').then((response) => {
            expect(response.statusCode).toBe(200);

            // console.log(JSON.stringify(response));

            done();
        });
    });
});


describe('Test the getModels path', () => {
    test('It should respond to the GET method', (done) => {
        request(app).get('/getModels').then((response) => {
            expect(response.statusCode).toBe(200);
            done();
        });
    });
});

describe('Test the uploadArtifacts path', () => {
    test('It should respond to the POST method', (done) => {
        request(app).post('/uploadArtifacts').then((response) => {
            expect(response.statusCode).toBe(200);
            done();
        });
    });
});


describe('Test the uploads path', () => {
    test('It should respond to the GET method', (done) => {
        request(app).post('/uploads').then((response) => {
            expect(response.statusCode).toBe(404);
            done();
        });
    });
});


//
// describe('Test the root path', () => {
//     test('It should respond to the GET method', (done) => {
//         request(app).get('/').then((response) => {
//             expect(response.statusCode).toBe(200);
//             done();
//         });
//     });
// });
//
// describe('Test the root path', () => {
//     test('It should respond to the GET method', (done) => {
//         request(app).get('/').then((response) => {
//             expect(response.statusCode).toBe(200);
//             done();
//         });
//     });
// });
//
// describe('Test the root path', () => {
//     test('It should respond to the GET method', (done) => {
//         request(app).get('/').then((response) => {
//             expect(response.statusCode).toBe(200);
//             done();
//         });
//     });
// });

// var formData = {
//     // Pass a simple key-value pair
//     artifactName: 'n',
//     // Pass data via Buffers
//     artifactDescription: 'd',
//     // Pass data via Streams
//     // my_file: fs.createReadStream(__dirname + '/unicycle.jpg'),
//     // Pass multiple values /w an Array
//     // attachments: [
//     //     fs.createReadStream('files/a'),
//     //     fs.createReadStream('files/b')
//     // ]
// };
//
// describe('Sever API test', function () {
//
//     it('Uploads files successfully', function () {
//
//
//         request.post({url:'http://127.0.0.1/uploadArtifacts', formData: formData}, function optionalCallback(err, httpResponse, body) {
//             let success = true;
//             if (err) {
//                 success = false;
//             }
//             else if(httpResponse.statusCode != 200) {
//                 success = false;
//             }
//
//             expect(success).toEqual(true);
//         });
//
//     });
//
//
//     it('Produces the correct response for an artifact ', function () {
//
//
//         database.connect(function (client, collection) {
//             database.getArtifactByName(client, collection, 'n', function (json) {
//                 expect(json.found).toEqual(true);
//             });
//         });
//
//
//     });
//
// });
