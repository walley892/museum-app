const express = require('express');

const app = express();

require('./app/routes')(express, app);

module.exports = app;
