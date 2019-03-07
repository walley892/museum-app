const express = require('express');

const app = express();

const port = process.env.PORT || 8080;

require('./app/routes')(express, app);

app.listen(port, function() {
console.log('Live on ' + port);
});            