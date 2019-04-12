var path = require('path');

module.exports = {
    route: route,
    getResponse: getResponse
}


function route(express, app) {
    app.use('/uploads', express.static( __dirname + '/../uploads' ));
}

function getResponse(ans) {

    return {'status' : ans};
}